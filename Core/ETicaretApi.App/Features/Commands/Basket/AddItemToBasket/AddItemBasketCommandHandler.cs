using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.AddItemToBasket
{
   public class AddItemBasketCommandHandler : IRequestHandler<AddItemBasketCommandRequest, AddItemBasketCommandResponse>
   {
     readonly private IBasketService _basketService;
     

     public AddItemBasketCommandHandler(IBasketService basketService)
     {
        _basketService=basketService;
     }
      public async Task<AddItemBasketCommandResponse> Handle(AddItemBasketCommandRequest request, CancellationToken cancellationToken)
      {
        await  _basketService.AddItemToBasketAsync(new(){
            ProductId=request.ProductId,
            Quantity=request.Quantity
         });

         return new();
      }
   }
}