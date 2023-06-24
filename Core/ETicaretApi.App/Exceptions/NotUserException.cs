using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Exceptions
{
    public class NotUserException:Exception
    {
         public NotUserException():base("No such user exists"){}
         public NotUserException(string? message):base(message){}
         public NotUserException(string? message, Exception? innerException):base(message , innerException){}
       
    }
}