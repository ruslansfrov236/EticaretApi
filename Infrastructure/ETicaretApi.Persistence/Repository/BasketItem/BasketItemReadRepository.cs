using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.BasketItem;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.BasketItem
{
   public class BasketItemReadRepository : ReadRepository<E::BasketItem>, IBasketItemReadRepository
   {
      public BasketItemReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}