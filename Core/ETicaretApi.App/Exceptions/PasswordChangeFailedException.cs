using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Exceptions
{
    public class PasswordChangeFailedException:Exception
    {
           public   PasswordChangeFailedException():base("An error occurred while resetting the password."){

      }

      public PasswordChangeFailedException(string? message):base(message){

      }

      public PasswordChangeFailedException(string? message , Exception? innerException):base(message , innerException){
        
      }
    }
}