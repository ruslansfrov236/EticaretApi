using System.Text.Json;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Services.Authentication;
using ETicaretApi.App.Abstractions.Token;
using ETicaretApi.App.DTOs;
using ETicaretApi.App.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E=ETicaretApi.Domain.Entity.Identity;
namespace ETicaretApi.App.Features.Commands.AppUser.FacebookLogin
{
   public class FacebookLoginCommandsHandle : IRequestHandler<FacebookLoginCommandsRequest, FacebookLoginCommandsResponse>
   {
       readonly private IExternalAuthentication _authService;

    public FacebookLoginCommandsHandle(IExternalAuthentication authService)
    {
        _authService=authService;
    }
      public  async Task<FacebookLoginCommandsResponse> Handle(FacebookLoginCommandsRequest request, CancellationToken cancellationToken)
      {
       var  token= await _authService.FacebookLoginAsync(request?.AuthToken , 900);


       return new(){
         Token=token
       };

      }
   }
}
