﻿using ETicaretApi.App.Repository.Customer;
using ETicaretApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = ETicaretApi.Domain.Entity;
namespace ETicaretApi.Persistence.Repository.Customer
{
    public class CustomerReadRepository : ReadRepository<E.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(ETicaretApiDbContext context) : base(context)
        {
        }
    }
}