using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services.Authentication;
using ETicaretApi.App.DTOs;
using MediatR;

namespace ETicaretApi.App.Features.Commands.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandsHandler:IRequestHandler<RefreshTokenLoginCommandsRequest , RefreshTokenLoginCommandsResponse>
    {

       readonly private IInternalAuthentication _authService;


        public RefreshTokenLoginCommandsHandler(IInternalAuthentication authService)
        {
            _authService=authService;
        }

      public async Task<RefreshTokenLoginCommandsResponse> Handle(RefreshTokenLoginCommandsRequest request, CancellationToken cancellationToken)
      {
       Token? token =  await  _authService.RefreshTokenLoginAsync(request.RefreshToken);

       return new(){
         Token=token
       };
      }
   }
}