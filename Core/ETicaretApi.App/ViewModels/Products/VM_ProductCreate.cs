﻿using ETicaretApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.App.ViewModels.Products
{
    public class VM_ProductCreate
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
