using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Users.GetRolesToUser
{
   public class GetRolesToUserQueriesHandler : IRequestHandler<GetRolesToUserQueriesRequest, GetRolesToUserQueriesResponse>
   {

       readonly private IUserService _userService;
    public GetRolesToUserQueriesHandler(IUserService userService)
      {
         _userService = userService;
      }

      public async Task<GetRolesToUserQueriesResponse> Handle(GetRolesToUserQueriesRequest request, CancellationToken cancellationToken)
      {
        var userRoles=  await _userService.GetRoleToUserAsync(request.UserId);

          return new(){
            userRoles=userRoles,
            
          };
      }
   }
}