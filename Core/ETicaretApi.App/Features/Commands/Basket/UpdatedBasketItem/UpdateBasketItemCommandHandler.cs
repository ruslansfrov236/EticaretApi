using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.UpdatedBasketItem
{
   public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
   {
      readonly private IBasketService _basketService;

      public UpdateBasketItemCommandHandler(IBasketService basketService)
      {
        _basketService=basketService;
      }
      public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
      {
       await _basketService.UpdateQuantityAsync(new (){
            BasketItemId=request.BasketItemId,
            Quantity=request.Quantity
          });

          return new (){};
      }
   }
}