
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Services.Authentication;
using ETicaretApi.App.Repository.Basket;
using ETicaretApi.App.Repository.BasketItem;
using ETicaretApi.App.Repository.CompletedOrder;
using ETicaretApi.App.Repository.Customer;
using ETicaretApi.App.Repository.Endoint;
using ETicaretApi.App.Repository.File;
using ETicaretApi.App.Repository.InvoiceFile;
using ETicaretApi.App.Repository.Menu;
using ETicaretApi.App.Repository.Order;
using ETicaretApi.App.Repository.Product;
using ETicaretApi.App.Repository.ProductImageFile;
using ETicaretApi.Domain.Entity.Identity;
using ETicaretApi.Infrastructure.Service;
using ETicaretApi.Persistence.Context;
using ETicaretApi.Persistence.Repository;
using ETicaretApi.Persistence.Repository.Basket;
using ETicaretApi.Persistence.Repository.BasketItem;
using ETicaretApi.Persistence.Repository.CompetedOrder;
using ETicaretApi.Persistence.Repository.Customer;
using ETicaretApi.Persistence.Repository.Endpoint;
using ETicaretApi.Persistence.Repository.File;
using ETicaretApi.Persistence.Repository.InvoiceFile;
using ETicaretApi.Persistence.Repository.Menu;
using ETicaretApi.Persistence.Repository.Order;
using ETicaretApi.Persistence.Repository.Product;
using ETicaretApi.Persistence.Repository.ProductImageFile;
using ETicaretApi.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretApi.Persistence
{
    public static class ServiceRegistration
    {
           public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretApiDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options=>{

                options.Password.RequiredLength=5;
                options.Password.RequireUppercase=false;
                options.Password.RequireNonAlphanumeric=false;
                options.Password.RequireLowercase=false;
                options.Password.RequireDigit=false;
              

            }).AddEntityFrameworkStores<ETicaretApiDbContext>()
              .AddDefaultTokenProviders();



            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IFileReadRepository , FileReadRepository>();
            services.AddScoped<IFileWriteRepository , FileWriteRepository>();
            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository , InvoiceFileWriteRepository>();
            services.AddScoped<IProductImageReadRepository , ProductImageReadRepository>();
            services.AddScoped<IProductImageWriteRepository , ProductImageWriteRepository>();
            services.AddScoped<IBasketReadRepository  , BasketReadRepistory>();
            services.AddScoped<IBasketWriteRepository  , BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository  , BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository  , BasketItemWriteRepository>();
            services.AddScoped<ICompletedOrderReadRepository , CompetedOrderReadRepository >();
            services.AddScoped<ICompletedOrderWriteRepository , CompetedOrderWriteRepository >();
            services.AddScoped<IEndpointReadRepository , EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository , EndpointWriteRepository>();
            services.AddScoped<IMenuWriteRepository , MenuWriteRepository>();
            services.AddScoped<IMenuReadRepository , MenuReadRepository>();
         


            services.AddScoped<IUserService , UserService>();
            services.AddScoped<IAuthService , AuthService>();
            services.AddScoped<IBasketService , BasketService>();
            services.AddScoped<IOrderService , OrderServices>();
            services.AddScoped<IRoleService , RoleService>();
            services.AddScoped<IAuthorizationEndpointService , AuthorizationEndpointService>();
            services.AddScoped<IProductService , ProductService>();

            
            services.AddScoped<IExternalAuthentication , AuthService>();
            services.AddScoped< IInternalAuthentication ,AuthService>();
         




        }
    }
}