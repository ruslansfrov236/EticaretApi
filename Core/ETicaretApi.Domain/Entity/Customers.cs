using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        // public ICollection<Order> Orders { get; set; }
    }
}
