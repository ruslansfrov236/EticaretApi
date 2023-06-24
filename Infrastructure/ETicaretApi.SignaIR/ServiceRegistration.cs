using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Hubs;
using ETicaretApi.SignaIR.HubService;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretApi.SignaIR
{
    public static class ServiceRegistration
    {
        public static void AddSignaIRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IProductHubService , ProductHubService>();
            collection.AddTransient<IOrderHubService , OrderHubService>();
            collection.AddSignalR();
        }
    }
}