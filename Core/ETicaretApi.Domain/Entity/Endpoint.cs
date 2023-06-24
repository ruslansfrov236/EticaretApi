using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Common;
using ETicaretApi.Domain.Entity.Identity;

namespace ETicaretApi.Domain.Entity
{
    public class Endpoint:BaseEntity
    {
       public Endpoint()
        {
            Roles= new HashSet<AppRole>();
        }
      public string? ActionType {get; set;}
      public string? HttpType {get; set;}
      public string? Definition{get; set;}
      public string? Code{get; set;}
      public Menu? Menu {get; set;}
      public ICollection<AppRole> Roles {get;set;}
    }
}