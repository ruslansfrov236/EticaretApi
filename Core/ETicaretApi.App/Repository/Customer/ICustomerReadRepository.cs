using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Repository.Customer
{
    public interface ICustomerReadRepository:IReadRepository<E::Customer>
    {
    }
}
