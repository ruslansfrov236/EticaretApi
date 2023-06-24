using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Menu;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Menu
{
   public class MenuWriteRepository : WriteRepository<E::Menu>, IMenuWriteRepository
   {
      public MenuWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}