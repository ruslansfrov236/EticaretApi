using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Orders.CompletedOrder
{
    public class CompletedOrderCommandsRequest:IRequest<CompletedOrderCommandsResponse>
    {
        public string id {get; set;}
    }
}