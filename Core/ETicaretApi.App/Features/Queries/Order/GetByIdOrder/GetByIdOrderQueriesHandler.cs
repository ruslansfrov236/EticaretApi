using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Order.GetByIdOrder
{
   public class GetByIdOrderQueriesHandler : IRequestHandler<GetByIdOrderQueriesRequest, GetByIdOrderQueriesResponse>
   {
      readonly private IOrderService _orderService;

      public GetByIdOrderQueriesHandler(IOrderService orderService)
      {
        _orderService=orderService;
      }
      public async Task<GetByIdOrderQueriesResponse> Handle(GetByIdOrderQueriesRequest request, CancellationToken cancellationToken)
      {
         var data =  await _orderService.GetByIdOrder(request.Id);


           return new ()
           {
               id=data.id,
                BasketItems= data.BasketItems,
                Address=data.Address,
                OrderCode=data.OrderCode,
                CreatedDate=data.CreatedDate,
                Description=data.Description,
             


            };
      }
   }
}