using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.DTOs.Order
{
    public class CompletedOrders
    {
        public string To {get; set;}
        public string OrderCode {get; set;}
        public DateTime OrderDate {get; set;}
        public string UserName {get; set;}
        public string UserSurName {get; set;}
    }
}