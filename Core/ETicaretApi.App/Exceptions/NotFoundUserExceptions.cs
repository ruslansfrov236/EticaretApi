using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Exceptions
{
    public class NotFoundUserExceptions:Exception
    {
      public   NotFoundUserExceptions():base("Only username and email address and password are wrong"){

      }

      public NotFoundUserExceptions(string? message):base(message){

      }

      public NotFoundUserExceptions(string? message , Exception? innerException):base(message , innerException){
        
      }
    }
}