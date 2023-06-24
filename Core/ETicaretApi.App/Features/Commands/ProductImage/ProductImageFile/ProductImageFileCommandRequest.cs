using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretApi.App.Features.Commands.ProductImage.ProductImageFile
{
    public class ProductImageFileCommandRequest:IRequest<ProductImageFileCommandResponse>
    {
        public string Id {get; set;}
        public IFormFileCollection? Files { get; set; }
    }
}