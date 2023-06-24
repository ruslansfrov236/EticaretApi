using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Domain.Entity.Identity
{
    public class AppUser :IdentityUser<string>
    {
        public string? NameSurname { get; set;}
        public string? RefreshToken { get; set;}
        public DateTime? RefreshTokenEndDate { get; set;}

        public ICollection<Basket> Baskets {get; set;}
    }
}