using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.CompletedOrder;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.CompetedOrder
{
   public class CompetedOrderWriteRepository : WriteRepository<E::CompletedOrder>, ICompletedOrderWriteRepository
   {
      public CompetedOrderWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}