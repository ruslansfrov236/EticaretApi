using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E= ETicaretApi.App.DTOs;
namespace ETicaretApi.App.Abstractions.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<E::Token> FacebookLoginAsync( string authToken , int accessTokenLifeTime);
        Task<E::Token> GoogleLoginAsync(string idToken ,int accessTokenLifeTime);
       
    }
}