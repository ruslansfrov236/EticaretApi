using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AuthorizeEndpoints.AssignRole
{
   public class AssignRoleCommandsHandler : IRequestHandler<AssignRoleCommandsRequest, AssignRoleCommandsResponse>
   {
       readonly private IAuthorizationEndpointService _authorizationEndpointService;
      public AssignRoleCommandsHandler(IAuthorizationEndpointService authorizationEndpointService)
      {
         _authorizationEndpointService = authorizationEndpointService;
      }

      public async Task<AssignRoleCommandsResponse> Handle(AssignRoleCommandsRequest request, CancellationToken cancellationToken)
      {
        
         await   _authorizationEndpointService.AssignRoleEndpointAsync(request.Roles ,request.Menu ,request.Code , request.type);
         return new(){};
      }
   }
}