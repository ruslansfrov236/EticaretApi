using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Exceptions
{
    public class UserCreateFailedException:Exception
    {

        public UserCreateFailedException():base("An error occurred while creating the account")
        {
            
        }

        public UserCreateFailedException(string? message):base(message){

        }

        public UserCreateFailedException(string? message, Exception? innerException):base(message , innerException){

        }
        
    }
}