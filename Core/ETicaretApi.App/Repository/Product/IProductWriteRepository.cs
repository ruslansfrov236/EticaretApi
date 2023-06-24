using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Repository.Product
{
    public interface IProductWriteRepository:IWriteRepository<E::Product>
    {
    }
}
