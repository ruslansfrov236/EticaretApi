using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueriesRequest:IRequest<GetAllRoleQueriesResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}