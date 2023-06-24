using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.ViewModels.Baskets;
using ETicaretApi.Domain.Entity;

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IBasketService
    { public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(VM_BasketItemCreate basketItem);
        public Task UpdateQuantityAsync(VM_BasketItemUpdate basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
        public Basket? GetUserActiveBasket { get; }
    }
}