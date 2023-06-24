using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E=ETicaretApi.App.DTOs;   
namespace ETicaretApi.App.Abstractions.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<E::Token> LoginAsync(string password , string usernameOrEmail ,int accessTokenLifeTime);
        Task<DTOs.Token> RefreshTokenLoginAsync(string refreshToken);


    }
}