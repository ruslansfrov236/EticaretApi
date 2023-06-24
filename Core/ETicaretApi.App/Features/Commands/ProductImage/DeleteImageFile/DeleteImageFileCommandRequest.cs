using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.ProductImage.DeleteImageFile
{
    public class DeleteImageFileCommandRequest:IRequest<DeleteImageFileCommandResponse>
    {
        public string Id {get; set;}
        public string? ImageId {get; set;}

    }
}