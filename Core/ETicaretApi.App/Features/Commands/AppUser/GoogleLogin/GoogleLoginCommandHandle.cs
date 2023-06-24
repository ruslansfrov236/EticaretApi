using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Abstractions.Services.Authentication;
using ETicaretApi.App.Abstractions.Token;
using ETicaretApi.App.DTOs;

using MediatR;
using Microsoft.AspNetCore.Identity;
using E=ETicaretApi.Domain.Entity.Identity;
namespace ETicaretApi.App.Features.Commands.AppUser.GoogleLogin
{
   public class GoogleLoginCommandHandle : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
   {
       private readonly IExternalAuthentication _authService;


       public GoogleLoginCommandHandle(IExternalAuthentication authService)
       {
        _authService=authService;
       }
    
      public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
      {
        var token = await  _authService.GoogleLoginAsync(request?.IdToken , 900);

        return new (){
            Token=token
        };
      }
   }
}