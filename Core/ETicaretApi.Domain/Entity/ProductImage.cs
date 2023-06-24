using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entity
{
    public class ProductImage:File
    {
         public bool ShowCase { get; set;}
        public ICollection<Product> Product {get; set;}
    }
}