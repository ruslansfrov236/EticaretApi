using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Basket;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Basket
{
   public class BasketReadRepistory : ReadRepository<E::Basket>, IBasketReadRepository
   {
      public BasketReadRepistory(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}