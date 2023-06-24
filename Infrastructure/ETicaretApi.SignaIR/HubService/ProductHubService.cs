using ETicaretApi.App.Abstractions.Hubs;
using ETicaretApi.SignaIR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.SignaIR.HubService
{
    public class ProductHubService : IProductHubService
    {

         readonly private IHubContext<ProductHub>  _hubContext;

         public ProductHubService(IHubContext<ProductHub>  hubContext)
         {
            _hubContext=hubContext;
         }
        public async Task ProductAddedMessageAsync(string message)
        {
          await  _hubContext.Clients.All.SendAsync( ReceiveProductName.receiveOrderAddedMessage, message);
        }
    }
}
