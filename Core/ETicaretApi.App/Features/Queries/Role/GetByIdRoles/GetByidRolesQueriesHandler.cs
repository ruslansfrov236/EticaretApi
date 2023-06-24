using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Role.GetByIdRoles
{
   public class GetByidRolesQueriesHandler : IRequestHandler<GetByidRolesQueriesRequest, GetByidRolesQueriesResponse>
   {

     readonly private IRoleService _roleService;

     public GetByidRolesQueriesHandler(IRoleService roleService)
     {
        _roleService=roleService;
     }
      public async Task<GetByidRolesQueriesResponse> Handle(GetByidRolesQueriesRequest request, CancellationToken cancellationToken)
      {
       var result = await  _roleService.GetByIdRoles( request.Id);

        return new (){
            Id=result.id,
            Name=result.name
        };
      }
   }
}