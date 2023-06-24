using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.DeleteRole
{
   public class DeleteRoleCommandsHandler : IRequestHandler<DeleteRoleCommandsRequest, DeleteRoleCommandsResponse>
   {
       readonly private IRoleService _roleService;

       public DeleteRoleCommandsHandler(IRoleService roleService)
       {
        _roleService=roleService;
       }
      public async Task<DeleteRoleCommandsResponse> Handle(DeleteRoleCommandsRequest request, CancellationToken cancellationToken)
      {
       var result= await  _roleService.DeleteRole(request.Id);

        return new (){
            Succeeded=result
        };
      }
   }
}