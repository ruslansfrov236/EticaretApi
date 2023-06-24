using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Abstractions.Hubs
{
    public interface IOrderHubService
    {
        Task OrderAddedMessageAsync ( string message);
    }
}