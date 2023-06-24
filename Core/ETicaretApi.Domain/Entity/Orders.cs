using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class Order:BaseEntity
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode {get; set;}
        public Basket Basket {get; set;}
        public CompletedOrder CompletedOrders{get;set;}
         //  public ICollection<Product>? Products { get; set; }
        // public Guid CustomerId { get; set; }
        // public Customer Customers { get; set; }
    }
}
