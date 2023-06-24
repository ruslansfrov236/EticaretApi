using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Exceptions
{
    public class AuthenticationErrorException:Exception
    {
        

        public AuthenticationErrorException():base("The user did not verify the account") {}

        public AuthenticationErrorException(string? message):base(message)
        { }

        public AuthenticationErrorException(string? message , Exception? innerException):base(message , innerException){}
    }
}