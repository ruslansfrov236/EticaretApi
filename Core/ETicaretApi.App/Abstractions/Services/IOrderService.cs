using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.DTOs.Order;


namespace ETicaretApi.App.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrder(OrderCreate orderCreate);
        Task <ListOrder> GetListOrderAsync(int page , int size);
        Task <SingleOrder> GetByIdOrder( string id);
        Task <(bool , CompletedOrders)>CompletedOrderAsync(string id);
    }
}