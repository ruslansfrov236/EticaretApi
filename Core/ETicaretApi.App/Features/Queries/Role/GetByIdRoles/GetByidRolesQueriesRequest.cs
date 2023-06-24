using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Role.GetByIdRoles
{
    public class GetByidRolesQueriesRequest:IRequest<GetByidRolesQueriesResponse>
    {
           public string Id {get; set;}
        public string Name {get; set;}
    }
}