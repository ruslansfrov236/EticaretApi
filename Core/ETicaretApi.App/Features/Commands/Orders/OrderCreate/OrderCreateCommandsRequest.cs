using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Orders.OrderCreate
{
    public class OrderCreateCommandsRequest:IRequest<OrderCreateCommandsResponse>
    {
            public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
    }
}