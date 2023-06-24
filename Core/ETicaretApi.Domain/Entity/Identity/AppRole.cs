using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Domain.Entity.Identity
{
    public class AppRole:IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints{get; set;}
    }
}