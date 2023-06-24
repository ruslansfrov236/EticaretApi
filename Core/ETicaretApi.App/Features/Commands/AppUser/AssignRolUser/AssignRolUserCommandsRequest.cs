using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.AssignRolUser
{
    public class AssignRolUserCommandsRequest:IRequest<AssignRolUserCommandsResponse>
    {
        public string UserId {get; set;}
        public string[] Roles {get; set;}
    }
}