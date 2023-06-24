using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.AuthorizeEndpoints.GetRolesToEndpoint
{
   public class GetRolesToEndpointQueriesHandler : IRequestHandler<GetRolesToEndpointQueriesRequest, GetRolesToEndpointQueriesResponse>
   {  
       readonly private IAuthorizationEndpointService   _authorizationEndpointService;

      public GetRolesToEndpointQueriesHandler(IAuthorizationEndpointService authorizationEndpointService)
      {
         _authorizationEndpointService = authorizationEndpointService;
      }

      public async Task<GetRolesToEndpointQueriesResponse> Handle(GetRolesToEndpointQueriesRequest request, CancellationToken cancellationToken)
      {
        var datas= await _authorizationEndpointService.GetRolesToEndpointAsync(request.Code, request.Menu);

         return new(){
            Roles=datas
         };
      }
   }
}
