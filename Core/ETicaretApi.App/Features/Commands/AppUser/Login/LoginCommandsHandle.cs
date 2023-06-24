using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services.Authentication;
using ETicaretApi.App.Abstractions.Token;
using ETicaretApi.App.DTOs;
using ETicaretApi.App.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E = ETicaretApi.Domain.Entity.Identity;
namespace ETicaretApi.App.Features.Commands.AppUser.Login
{
   public class LoginCommandsHandle : IRequestHandler<LoginCommandsRequest, LoginCommandsResponse>
   {
    
      readonly private IInternalAuthentication _authService;
      public LoginCommandsHandle(IInternalAuthentication authService)
      {
        _authService=authService;
      }
      public Exception NotFoundUserException { get; private set; }

      public async Task<LoginCommandsResponse> Handle(LoginCommandsRequest request, CancellationToken cancellationToken)
      {

    var token = await _authService.LoginAsync(request.password ,request.UsernameOrEmail ,900);
      return new LoginSuccessCommandResponse(){
          Token=token
         };
      }
   }
}