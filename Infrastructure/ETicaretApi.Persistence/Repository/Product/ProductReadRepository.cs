using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Product
{
   public class ProductReadRepository : ReadRepository<E.Product>, IProductReadRepository
   {
      public ProductReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }

   
   }
}