using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.AddItemToBasket
{
    public class AddItemBasketCommandRequest:IRequest<AddItemBasketCommandResponse>
    {
        public string? ProductId {get; set;}
        public int Quantity {get; set;}
    }
}