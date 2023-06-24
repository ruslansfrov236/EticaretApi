using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Endoint;
using ETicaretApi.Persistence.Context;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Endpoint
{
   public class EndpointWriteRepository : WriteRepository<E::Endpoint>, IEndpointWriteRepository
   {
      public EndpointWriteRepository(ETicaretApiDbContext context) : base(context)
      {
      }
   }
}