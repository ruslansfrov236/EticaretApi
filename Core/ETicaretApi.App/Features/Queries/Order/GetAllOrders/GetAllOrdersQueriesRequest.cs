using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueriesRequest:IRequest<GetAllOrdersQueriesResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
        
    }
}