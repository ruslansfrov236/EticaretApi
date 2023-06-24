using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Repository.Basket;
using ETicaretApi.Domain.Entity;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Basket.DeleteBasketItem
{
   public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
   {
      readonly private IBasketService  _basketService;
      readonly private IBasketReadRepository _basketReadRepository;

      public DeleteBasketItemCommandHandler(IBasketService  basketService ,  IBasketReadRepository basketReadRepository)
      {
        _basketService=basketService;
        _basketReadRepository=basketReadRepository;
      }
      public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
      {
     
        await _basketService.RemoveBasketItemAsync(request.BasketItemId);

         return new ();
      }
   }
}