using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ETicaretApi.App.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueriesResponse
    {
           public string Address {get; set;}
        public object BasketItems {get; set;}
        public DateTime CreatedDate {get; set;}
        public string id {get; set;}
        public string OrderCode {get; set;}
        public string  Description{get; set;}
    }
}