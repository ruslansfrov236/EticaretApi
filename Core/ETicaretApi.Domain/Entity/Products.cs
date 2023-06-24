using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        // public ICollection<Order>? Orders { get; set; }

        public ICollection<ProductImage> ProductImages {get; set;}
      public ICollection<BasketItem> BasketItems {get; set;}
    }
}
