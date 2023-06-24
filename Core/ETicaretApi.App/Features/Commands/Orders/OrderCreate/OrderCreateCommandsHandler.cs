using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Hubs;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Orders.OrderCreate
{
   public class OrderCreateCommandsHandler : IRequestHandler<OrderCreateCommandsRequest, OrderCreateCommandsResponse>
   {
       readonly private  IOrderService _orderService;
       readonly private IBasketService _basketService;
       readonly IOrderHubService _hubService;

       public OrderCreateCommandsHandler(IOrderService orderService , IBasketService basketService , IOrderHubService hubService)
       {
          _orderService=orderService;
          _basketService=basketService;
          _hubService=hubService;
       }
      public async Task<OrderCreateCommandsResponse> Handle(OrderCreateCommandsRequest request, CancellationToken cancellationToken)
      {
        await  _orderService.CreateOrder(new(){
            BasketId=_basketService.GetUserActiveBasket?.id.ToString(), 
             Name=request.Name,
             Address=request.Address,
             Description=request.Description
        });

        _hubService.OrderAddedMessageAsync($"Yeni sifaris geldi {request.Name}");
        return new ();
      }
   }
}