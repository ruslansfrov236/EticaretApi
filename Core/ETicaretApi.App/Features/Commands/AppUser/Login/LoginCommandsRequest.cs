using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.Login
{
    public class LoginCommandsRequest:IRequest<LoginCommandsResponse>
    {
        public string? UsernameOrEmail { get; set;}
        public string password { get; set; }
    }
}