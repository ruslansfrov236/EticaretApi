using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services.Authentication;

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IAuthService:IExternalAuthentication , IInternalAuthentication
    {

        Task  PasswordResetAsync(string email);
        Task <bool> VerifyResetToken(string resetToken , string userId);
    }
}