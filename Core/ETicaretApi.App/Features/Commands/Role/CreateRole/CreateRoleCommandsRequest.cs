using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandsRequest:IRequest<CreateRoleCommandsResponse>
    {
        public string Name {get; set;}
    }
}