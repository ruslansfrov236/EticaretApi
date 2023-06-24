using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.Domain.Entity.Identity;
using E=ETicaretApi.App.DTOs;
namespace ETicaretApi.App.Abstractions.Token
{
    public interface ITokenHandler
    {
        E::Token CreateAccessToken(int second ,AppUser appUser);
        string CreateRefreshToken ();
    }
}