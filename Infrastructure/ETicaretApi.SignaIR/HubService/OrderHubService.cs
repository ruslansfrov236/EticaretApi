using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Hubs;
using ETicaretApi.SignaIR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ETicaretApi.SignaIR.HubService
{
   public class OrderHubService : IOrderHubService
   {
        readonly private IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext=hubContext;
        }
      public async Task OrderAddedMessageAsync(string message)
        => await  _hubContext.Clients.All.SendAsync( ReceiveProductName.receiveProductAddedMessage, message);
   }
}