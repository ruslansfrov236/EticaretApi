using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.DTOs;

namespace ETicaretApi.App.Features.Commands.AppUser.Login
{
    public class LoginCommandsResponse
    {
     
    }

    public class LoginSuccessCommandResponse :LoginCommandsResponse
    {
            public Token Token {get; set;}
    }
      public class LoginErrorCommandResponse :LoginCommandsResponse
      {
           
        public string Message {get; set;}

      }
}