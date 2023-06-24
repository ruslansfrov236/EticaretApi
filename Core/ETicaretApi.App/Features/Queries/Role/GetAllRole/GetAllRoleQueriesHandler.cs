using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Role.GetAllRole
{
   public class GetAllRoleQueriesHandler : IRequestHandler<GetAllRoleQueriesRequest, GetAllRoleQueriesResponse>
   {
      readonly private IRoleService _roleService;

      public GetAllRoleQueriesHandler(IRoleService roleService)
      {
        _roleService=roleService;
      }
      public async Task<GetAllRoleQueriesResponse> Handle(GetAllRoleQueriesRequest request, CancellationToken cancellationToken)
      {
       var (datas, count)=  _roleService.GetAllRoles(request.Page , request.Size);

       
         return new(){
           Datas=datas,
           TotalCount=count
          };
      }
   }
}