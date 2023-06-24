using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.DeleteRole
{
    public class DeleteRoleCommandsRequest:IRequest<DeleteRoleCommandsResponse>
    {
        public string Id {get; set;}
    }
}