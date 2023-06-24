using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.PasswordReset
{
   public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
   {    readonly private IAuthService _authService;

        public PasswordResetCommandHandler(IAuthService authService)
        {
            _authService=authService;
        }
      public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
      {
        await  _authService.PasswordResetAsync(request.Email);

        return new ();
      }
   }
}