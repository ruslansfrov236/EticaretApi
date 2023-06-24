using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.BasketItem;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.BasketItem
{
   public class BasketItemWriteRepository : WriteRepository<E::BasketItem> , IBasketItemWriteRepository
   {
      public BasketItemWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}