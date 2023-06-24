using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.ChangeShowCase
{
    public class ChangeShowCaseCommandsRequest:IRequest<ChangeShowCaseCommandsResponse>
    {
        public string? ImageId {get; set;}
        public string? ProductId {get; set;}
    }
}