using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entity
{
    public class InvoiceFile:File
    {
        public decimal Price {get; set;}
    }
}