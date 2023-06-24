using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.AssignRolUser
{
   public class AssignRolUserCommandsHandler : IRequestHandler<AssignRolUserCommandsRequest, AssignRolUserCommandsResponse>
   {
        readonly private IUserService _userService;

      public AssignRolUserCommandsHandler(IUserService userService)
      {
         _userService = userService;
      }

      public async Task<AssignRolUserCommandsResponse> Handle(AssignRolUserCommandsRequest request, CancellationToken cancellationToken)
      {
          await _userService.AssignRoleToUserAsync(request.UserId , request.Roles);

         return new ();
      }
   }
}