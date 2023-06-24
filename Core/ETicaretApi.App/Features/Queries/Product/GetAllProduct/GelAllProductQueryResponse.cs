using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Features.Queries.Product.GetAllProduct
{
    public class GelAllProductQueryResponse
    {
        public int TotalCount { get; set; }
        public object? Products { get; set; }
    }
}