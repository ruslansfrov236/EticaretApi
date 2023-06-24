using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Features.Queries.Basket.GetBaskettem;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Basket.GetBasketItem
{
   public class GetBasketItemQueryHandler : IRequestHandler<GetBasketItemQueryRequest, List<GetBasketItemQueryResponse>>
   {  
     
      readonly private IBasketService _basketService;
      

      public GetBasketItemQueryHandler(IBasketService basketService)
      {
        _basketService=basketService;
      }

      public async Task<List<GetBasketItemQueryResponse>> Handle(GetBasketItemQueryRequest request, CancellationToken cancellationToken)
      {
           var basketItems = await  _basketService.GetBasketItemsAsync();

       return basketItems.Select(ba=> new GetBasketItemQueryResponse{
                BasketItemId= ba.id.ToString(),
                Name=ba.Product.Name,
                Price= ba.Product.Price,
                Quantity=ba.Quantity
       }).ToList();
      }
   }
}