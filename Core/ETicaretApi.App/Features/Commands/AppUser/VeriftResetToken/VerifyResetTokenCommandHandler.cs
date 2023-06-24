using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.VeriftResetToken
{
   public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommandRequest, VerifyResetTokenCommandResponse>
   {   readonly IAuthService _authService;

     public VerifyResetTokenCommandHandler(IAuthService authService)
     {
        _authService=authService;
     }
      public async Task<VerifyResetTokenCommandResponse> Handle(VerifyResetTokenCommandRequest request, CancellationToken cancellationToken)
      {
      bool state=  await  _authService.VerifyResetToken(request.ResetToken , request.UserId);

       return new(){
         State=state
       };
      }
   }
}