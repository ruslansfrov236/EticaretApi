using ETicaretApi.App.Repository.Product;
using ETicaretApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Product
{
    public class ProductWriteRepository : WriteRepository<E.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}
