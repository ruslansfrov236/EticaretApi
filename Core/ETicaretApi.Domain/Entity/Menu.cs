using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;

namespace ETicaretApi.Domain.Entity
{
    public class Menu:BaseEntity
    {
        public string Name {get; set;}
        public ICollection<Endpoint> Endpoints {get;set;}
    }
}