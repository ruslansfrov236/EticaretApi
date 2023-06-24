using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.AuthorizeEndpoints.GetRolesToEndpoint
{
    public class GetRolesToEndpointQueriesRequest:IRequest<GetRolesToEndpointQueriesResponse>
    {
        public string Code {get; set;}
        public string Menu {get; set;}
    }
}