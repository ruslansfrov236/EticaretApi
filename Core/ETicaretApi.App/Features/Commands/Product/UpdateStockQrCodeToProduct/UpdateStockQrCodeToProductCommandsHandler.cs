using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Product.UpdateStockQrCodeToProduct
{

  
   public class UpdateStockQrCodeToProductCommandsHandler : IRequestHandler<UpdateStockQrCodeToProductCommandsRequest, UpdateStockQrCodeToProductCommandsResponse>
   {
       readonly private IProductService _productService;

      public UpdateStockQrCodeToProductCommandsHandler(IProductService productService)
      {
         _productService = productService;
      }

      public async Task<UpdateStockQrCodeToProductCommandsResponse> Handle(UpdateStockQrCodeToProductCommandsRequest request, CancellationToken cancellationToken)
      {
         await _productService.StockUpdateToProductAsync(request.ProductId, request.Stock);

         return new();
      }
   }
}