using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Product.DeleteProduct
{
    public class DeleteProductCommonRequest:IRequest<DeleteProductCommonResponse>
    {
        public string Id {get; set;}
    }
}