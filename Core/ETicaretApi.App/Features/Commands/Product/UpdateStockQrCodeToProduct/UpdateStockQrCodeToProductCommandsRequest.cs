using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Product.UpdateStockQrCodeToProduct
{
    public class UpdateStockQrCodeToProductCommandsRequest:IRequest<UpdateStockQrCodeToProductCommandsResponse>
    {
        public string ProductId {get; set;}
        public int Stock {get; set;}
    }
}