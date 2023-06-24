using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.UpdatedRole
{
   public class UpdatedRoleCommandsHandler : IRequestHandler<UpdatedRoleCommandsRequest, UpdatedRoleCommandsResponse>
   {  
       readonly private  IRoleService _roleService;

       public UpdatedRoleCommandsHandler( IRoleService roleService)
       {
          _roleService=roleService;
       }
      public async Task<UpdatedRoleCommandsResponse> Handle(UpdatedRoleCommandsRequest request, CancellationToken cancellationToken)
      {
      var result=   await _roleService.UpdatedRole(request.Id , request.Name);


         return new (){
            Succeeded=result
         };
      }
   }
}