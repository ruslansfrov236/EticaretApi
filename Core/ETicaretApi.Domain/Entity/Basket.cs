using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;
using ETicaretApi.Domain.Entity.Identity;

namespace ETicaretApi.Domain.Entity
{
    public class Basket:BaseEntity
    {
        public string  UserId {get; set;}
     
        public AppUser User { get; set; }
        public Order Orders {get; set;}
        public ICollection<BasketItem> BasketItems {get; set;}
    }
}