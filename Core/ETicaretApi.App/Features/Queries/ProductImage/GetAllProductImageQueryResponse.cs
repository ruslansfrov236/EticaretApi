using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETicaretApi.App.Features.Queries.ProductImage
{
    public class GetAllProductImageQueryResponse
    {
        public Guid id { get; set;}
        public string? Path {get; set;}
        public  string? FileName {get; set;}

        
    }
}