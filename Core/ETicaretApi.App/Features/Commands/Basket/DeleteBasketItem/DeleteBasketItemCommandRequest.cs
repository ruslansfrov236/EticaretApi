using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.DeleteBasketItem
{
    public class DeleteBasketItemCommandRequest:IRequest<DeleteBasketItemCommandResponse>
    {
        public string? BasketItemId {get; set;}
    }
}