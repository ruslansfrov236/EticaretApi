using ETicaretApi.App.Repository.Order;
using ETicaretApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Order
{
    public class OrderReadRepository : ReadRepository<E::Order>, IOrderReadRepository
    {
        public OrderReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
