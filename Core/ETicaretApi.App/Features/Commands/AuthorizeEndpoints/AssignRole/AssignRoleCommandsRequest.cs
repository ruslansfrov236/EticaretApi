using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.AuthorizeEndpoints.AssignRole
{
    public class AssignRoleCommandsRequest:IRequest<AssignRoleCommandsResponse>
    {
        public string[] Roles {get; set;}

        public string Code {get; set;}
        public string Menu {get; set;}
        public Type? type {get; set;}
    }
}