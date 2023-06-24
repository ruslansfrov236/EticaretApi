using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Menu;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Menu
{
   public class MenuReadRepository : ReadRepository<E::Menu>, IMenuReadRepository
   {
      public MenuReadRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}