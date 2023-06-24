using System.Text;
using System.Text.Json;

using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Token;
using ETicaretApi.App.DTOs;
using ETicaretApi.App.DTOs.Facebook;
using ETicaretApi.App.Exceptions;
using ETicaretApi.App.Features.Commands.AppUser.Login;
using ETicaretApi.App.Helpers;
using ETicaretApi.Domain.Entity.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

namespace ETicaretApi.Persistence.Services
{
   public class AuthService : IAuthService
   {

        readonly private UserManager<AppUser>  _userManager;
        readonly private ITokenHandler _tokenHandler;
        readonly private IConfiguration _configuration;
        readonly private HttpClient _httpClient;
         readonly private SignInManager<AppUser>  _signinManager;
         readonly  private  IUserService _userService;
         readonly private IMailService _mailService;

        public AuthService(
            ITokenHandler tokenHandler,
            UserManager<AppUser>  userManager,
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            SignInManager<AppUser>  signinManager,
             IUserService userService,
             IMailService mailService
            
        )
        {
            _tokenHandler=tokenHandler;
            _userManager=userManager;
            _httpClient=httpClientFactory.CreateClient();
            _configuration=configuration;
            _signinManager=signinManager;
            _userService=userService;
            _mailService=mailService;
            
        }


      
      public async Task<Token> FacebookLoginAsync(string authToken ,int accessTokenLifeTime)
      {
             string accessTokenResponse= await  _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSettings:Facebook:Client_ID"]}&client_secret={_configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");
        FacebookAccessToken_Dto? facebookAccessToken=  JsonSerializer.Deserialize<FacebookAccessToken_Dto>(accessTokenResponse);
        string userAccessTokenValidators=   await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={authToken}&access_token={facebookAccessToken.AccessToken}");
        
         FacebookUserAccessTokenValidation? validation= 
                                      JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidators);


        if(validation?.Data?.IsValid !=null)
        {
                                        string userResponse= await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email ,name&access_token={authToken}");
                                      
                                                  FacebookUserInfoResponse? userInfoResponse=
                                                     JsonSerializer.Deserialize<FacebookUserInfoResponse>(userResponse);

      var info=  new UserLoginInfo("FACEBOOK", validation.Data.UserId , "FACEBOOK");

       AppUser? user=  await  _userManager.FindByLoginAsync(info.LoginProvider , info.ProviderKey);
       
   return   await  CreateUserExternalAsync(user , userInfoResponse.Email , userInfoResponse.Name , info ,accessTokenLifeTime);
      }
       throw new Exception("Invalid external authentication");
      }
      public async Task<Token> GoogleLoginAsync(string idToken ,int accessTokenLifeTime)
      {

  
           var settings=  new GoogleJsonWebSignature.ValidationSettings(){
            Audience=new List<string> { $"{_configuration["ExternalLoginSettings:Google:Client_ID"]}"  }

        };

       var payload= await GoogleJsonWebSignature.ValidateAsync(idToken , settings);

       var info=  new UserLoginInfo("GOOGLE", payload.Subject , "GOOGLE");


       AppUser user=  await  _userManager.FindByLoginAsync(info.LoginProvider , info.ProviderKey);
         return   await  CreateUserExternalAsync(user , payload.Email , payload.Name , info ,accessTokenLifeTime);
      }

      public async  Task<Token> LoginAsync(string password , string usernameOrEmail , int accessTokenLifeTime)
      {
         AppUser user=  await   _userManager.FindByNameAsync(usernameOrEmail);
        if(user==null){
            user =await _userManager.FindByEmailAsync(usernameOrEmail);
        }

         if (user==null)
        throw new  NotFoundUserExceptions("Only username and email address and password are wrong");
        
     SignInResult result=   await  _signinManager.CheckPasswordSignInAsync(user , password , false);
       if(result.Succeeded){
        Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime , user);
        await  _userService.UpdateRefreshToken(token.RefreshToken, user , token.Expiration, 900);
                 
         return token;

       
       }
        //  return new LoginErrorCommandResponse(){
        //   Message="Only username and email address and password are wrong"
        //  };


        throw new AuthenticationErrorException("The user did not verify the account");
        
      }

      public async Task PasswordResetAsync(string email)
      {
       AppUser user= await _userManager.FindByEmailAsync(email);

       if(user!=null){
        string resetToken =await _userManager.GeneratePasswordResetTokenAsync(user);

          resetToken=resetToken.UrlCode();

       await _mailService.SendPasswordResetMailAsync(email,  user.Id , resetToken);
       }
      }

      public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
      {
          AppUser? user =  _userManager.Users.FirstOrDefault(u=>u.RefreshToken==refreshToken);

          if(user!=null && user?.RefreshTokenEndDate>DateTime.UtcNow){

            Token token =  _tokenHandler.CreateAccessToken(15, user);
            await _userService.UpdateRefreshToken(token.RefreshToken , user  , token.Expiration , 900);
            return token;
          }

          throw new NotFoundUserExceptions();
      }

      public async Task<bool> VerifyResetToken(string resetToken, string userId)
      {
       AppUser user=  await _userManager.FindByIdAsync(userId);

       if(user!=null){
        resetToken= resetToken.UrlDecode();
        return  await  _userManager.VerifyUserTokenAsync(user , _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword" , resetToken);
       }
       return false;
      }

      async Task<Token> CreateUserExternalAsync(AppUser user , string email , string name , UserLoginInfo info , int accessTokenLifeTime){
      bool result= user!=null;
       if(user==null){
          user = await _userManager.FindByEmailAsync(email);
          if(user==null){
            user= new (){
                Id=Guid.NewGuid().ToString(),
                Email=email,
                UserName=email,
                NameSurname=name
            };

           var identityResult= await _userManager.CreateAsync(user);

           result=identityResult.Succeeded;
          }
          
       }

             if(result){
                  await  _userManager.AddLoginAsync(user , info);
                  Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime , user);
                  await  _userService.UpdateRefreshToken(token.RefreshToken, user , token.Expiration, 900 );
                  return token;

             }
               throw new Exception("Invalid external authentication");
        } 

        
    
        }
   }
