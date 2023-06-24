using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Users.GetRolesToUser
{
    public class GetRolesToUserQueriesRequest:IRequest<GetRolesToUserQueriesResponse>
    {
        public string UserId {get; set;}
    }
}