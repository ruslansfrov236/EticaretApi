using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Repository.BasketItem
{
    public interface IBasketItemReadRepository:IReadRepository<E::BasketItem>
    {
        
    }
}