using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommonRequest:IRequest<UpdateProductCommonResponse>
    {
        public string? Id { get; set; } 
       public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}