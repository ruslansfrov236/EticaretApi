using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.SignaIR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ETicaretApi.SignaIR
{
    public static class HubRegistration
    {
        public static void MapHubs( this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/products-hub");
            webApplication.MapHub<OrderHub>("/orders-hub");
        }
    }
}