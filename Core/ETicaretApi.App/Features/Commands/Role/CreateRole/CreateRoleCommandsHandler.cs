using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.CreateRole
{
   public class CreateRoleCommandsHandler : IRequestHandler<CreateRoleCommandsRequest, CreateRoleCommandsResponse>
   {
      readonly private IRoleService _roleService;
      public CreateRoleCommandsHandler(IRoleService roleService)
      {
        _roleService=roleService;
      }
      public async Task<CreateRoleCommandsResponse> Handle(CreateRoleCommandsRequest request, CancellationToken cancellationToken)
      {
     var result =  await  _roleService.CreateRole(request.Name);

       return new (){
        Succeeded=result
       };
      }
   }
}