using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandsRequest:IRequest<CreateUserCommandsResponse>
    {
        public string? NameSurname {get; set;}
        public string? UserName {get; set;}
        public string? Email {get; set;}
        public string? Password{get; set;}
        public string? RePassword {get; set;}
  
    }
}