using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Users.AppUser
{
   public class GetAllUserQueriesHandler : IRequestHandler<GetAllUserQueriesRequest, GetAllUserQueriesResponse>
   {
       readonly IUserService _userService;
      public GetAllUserQueriesHandler(IUserService userService)
      {
         _userService = userService;
      }

      public async Task<GetAllUserQueriesResponse> Handle(GetAllUserQueriesRequest request, CancellationToken cancellationToken)
      {
        var users= await  _userService.GetAllUsersAsync(request.page , request.size);

         return new(){
                Users =users, 
                TotalCount=_userService.TotalUsersCount
         };
      }
   }
}