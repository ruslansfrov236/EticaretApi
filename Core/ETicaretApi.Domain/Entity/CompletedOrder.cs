using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class CompletedOrder:BaseEntity
    {
        public Guid  OrderId {get; set;}

        public Order Orders {get; set;}
    }
}