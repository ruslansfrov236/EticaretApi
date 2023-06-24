using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandsResponse
    {
        public bool Succeeded {get; set;}

        public string? Message {get; set;}
    }
}