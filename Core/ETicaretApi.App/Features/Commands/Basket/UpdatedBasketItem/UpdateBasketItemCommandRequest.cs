using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.UpdatedBasketItem
{
    public class UpdateBasketItemCommandRequest:IRequest<UpdateBasketItemCommandResponse>
    {
        public string? BasketItemId{get; set;}
        public int Quantity{get; set;}
    }
}