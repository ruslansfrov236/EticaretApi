using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueriesRequest:IRequest<GetByIdOrderQueriesResponse>
    {
        public string Id {get; set;}
    }
}