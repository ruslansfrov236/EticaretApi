using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersQueriesResponse
    {
       public int TotalOrderCount {get; set;}

       public object  Orders {get; set;}
    }
}