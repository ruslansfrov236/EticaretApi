using ETicaretApi.App.DTOs.Order;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Orders.CompletedOrder
{
   public class CompletedOrderCommandsHandler : IRequestHandler<CompletedOrderCommandsRequest, CompletedOrderCommandsResponse>
   {

        readonly private  IOrderService _orderService;

        readonly private IMailService _mailService;

        public CompletedOrderCommandsHandler( IOrderService orderService ,IMailService mailService)
        {
            _orderService=orderService;
            _mailService=mailService;
        }
      public async Task<CompletedOrderCommandsResponse> Handle(CompletedOrderCommandsRequest request, CancellationToken cancellationToken)
      {
         (bool success , CompletedOrders dto) result=  await _orderService.CompletedOrderAsync(request.id);

         if(result.success){
           await    _mailService.SendCompletedOrderMailAsync( result.dto.To, result.dto.OrderCode,result.dto.OrderDate, result.dto.UserName, result.dto.UserSurName );
         }

         return new(){};
      }
   }
}