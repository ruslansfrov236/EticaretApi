using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Exceptions;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.PasswordUpdate
{
   public class PasswordUpdateCommandsHandler : IRequestHandler<PasswordUpdateCommandsRequest, PasswordUpdateCommandsResponse>
   { 
        readonly private IUserService _userService;

        public PasswordUpdateCommandsHandler(IUserService userService)
        {
            _userService=userService;
        }
      public async Task<PasswordUpdateCommandsResponse> Handle(PasswordUpdateCommandsRequest request, CancellationToken cancellationToken)
      {

        if(!request.newPassword.Equals(request.PasswordConfirmed))
         throw new PasswordChangeFailedException("Please confirm the password");
      await  _userService.UpdatedPassword(request.userId, request.resetToken, request.newPassword);

    
      return new ();
      }
   }
}