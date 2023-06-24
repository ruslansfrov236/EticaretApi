using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.AssignRoleDeleteUser
{
   public class AssignRoleDeleteUserCommandsHandler : IRequestHandler<AssignRoleDeleteUserCommandsRequest, AssignRoleDeleteUserCommandsResponse>
   {   
    readonly private IUserService _userService;
        public AssignRoleDeleteUserCommandsHandler(IUserService userService)
      {
         _userService = userService;
      }

      public async Task<AssignRoleDeleteUserCommandsResponse> Handle(AssignRoleDeleteUserCommandsRequest request, CancellationToken cancellationToken)
      {
        await  _userService.AssignRoleDeleteUser(request.UserId);

         return new();
      }
   }
}