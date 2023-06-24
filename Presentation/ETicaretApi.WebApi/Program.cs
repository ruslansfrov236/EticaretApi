using ETicaretApi.App;
using ETicaretApi.App.Validators.Product;
using ETicaretApi.Infrastructure;
using ETicaretApi.Infrastructure.Filters;
using ETicaretApi.Infrastructure.Service.Storage.Azure;
using ETicaretApi.Infrastructure.Service.Storage.Local;
using FluentValidation.AspNetCore;
using ETicaretApi.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Serilog.Sinks.PostgreSQL;
using System.Security.Claims;
using ETicaretApi.WebApi.Configuration.ColumnWrites;
using Serilog.Context;
using Serilog.Core;
using Serilog;
using Microsoft.AspNetCore.HttpLogging;
using ETicaretApi.WebApi.Extensions;
using ETicaretApi.SignaIR;
using ETicaretApi.SignaIR.Hubs;
using ETicaretApi.WebApi.Filter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructureServices();
builder.Services.AddSignaIRServices();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
// builder.Services.AddStorage(StorageType.Azure);
//builder.Services.AddStorage<AzureStorage>();
builder.Services.AddStorage<LocalStorage>();





builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
       // butun her kese istifade etmeye icaze verir  policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
       policy.WithOrigins("http://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));


Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt")
                .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL") , "logs" , 
                        needAutoCreateTable:true , 
                        columnOptions:new Dictionary<string,
                         ColumnWriterBase>
                         {
                           {"message", new RenderedMessageColumnWriter() },
                           {"message_template", new MessageTemplateColumnWriter() },
                           {"level"  , new LevelColumnWriter()},
                           {"time_stamp" , new TimestampColumnWriter()},
                           {"exception" , new ExceptionColumnWriter()},
                           {"log_event" , new LogEventSerializedColumnWriter()},
                           {"user_name" , new UsernameColumnWriter()}
                         })
                .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"] )
                .Enrich.FromLogContext()
                .MinimumLevel.Information()
                .CreateLogger();
builder.Host.UseSerilog(log);
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<RolePermissionFilter>();
   
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductCreateValidators>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                 .AddJwtBearer( "Admin" , options =>{
                                    options.TokenValidationParameters=new(){
                                        ValidateAudience=true,
                                        ValidateIssuer=true,
                                        ValidateIssuerSigningKey=true,
                                        ValidAudience=builder.Configuration["Token:Audience"],
                                        ValidIssuer=builder.Configuration["Token:Issuer"],
                                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                                        LifetimeValidator=( notBefore, expires, securityToken,  validationParameters)=>expires!=null ? expires>DateTime.UtcNow:false,
                                        NameClaimType=ClaimTypes.Name
                                    
                                    };
                                 });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseSerilogRequestLogging();
app.UseHttpLogging(); 

app.UseCors();
app.UseHttpsRedirection();
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("user_name", username);
    await next();
});


app.MapControllers();
app.MapHubs();
app.Run();
