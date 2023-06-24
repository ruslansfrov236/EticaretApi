using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AppUser.AssignRoleDeleteUser
{
    public class AssignRoleDeleteUserCommandsRequest:IRequest<AssignRoleDeleteUserCommandsResponse>
    {
        public string UserId {get; set;}
    }
}