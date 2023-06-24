using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.UpdatedRole
{
    public class UpdatedRoleCommandsRequest:IRequest<UpdatedRoleCommandsResponse>
    {
        public string Id {get; set;}
        public string Name {get; set;}
    }
}