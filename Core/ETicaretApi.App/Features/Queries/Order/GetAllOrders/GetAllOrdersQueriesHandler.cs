using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Order.GetAllOrders
{
   public class GetAllOrdersQueriesHandler : IRequestHandler<GetAllOrdersQueriesRequest,GetAllOrdersQueriesResponse>
   {   readonly private IOrderService _orderService;

         public GetAllOrdersQueriesHandler(IOrderService orderService)
         {
             _orderService=orderService;
         }
      public async Task<GetAllOrdersQueriesResponse> Handle(GetAllOrdersQueriesRequest request, CancellationToken cancellationToken)
      {
       var data = await  _orderService.GetListOrderAsync(request.Page , request.Size);

          return new (){
              TotalOrderCount=data.TotalOrderCount,
              Orders=data.Orders
          };
      
      }
   }
}