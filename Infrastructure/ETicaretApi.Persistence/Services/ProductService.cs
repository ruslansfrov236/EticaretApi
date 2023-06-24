
using System.Text.Json;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Repository.Product;
using ETicaretApi.Domain.Entity;

namespace ETicaretApi.Persistence.Services
{
   public class ProductService : IProductService
   {
       readonly IProductReadRepository _productReadRepository;
       readonly IProductWriteRepository _productWriteRepository;
       readonly IQRCodeService _qrcodeService;
      public ProductService(IProductReadRepository productReadRepository, IQRCodeService qrcodeService = null, IProductWriteRepository productWriteRepository = null)
      {
         _productReadRepository = productReadRepository;
         _qrcodeService = qrcodeService;
         _productWriteRepository = productWriteRepository;
      }

      public async Task<byte[]> ProductQrCodeAsync(string productId)
      {
        Product product = await _productReadRepository.GetByIdAsync(productId);
        if(product==null)
            throw new Exception("Product not found");


            var plainObject=new{
                product.id,
                product.Name,
                product.Stock,
                product.CreatedDate
            };

        string plainText= JsonSerializer.Serialize(plainObject);
          return  _qrcodeService.GenerateQRCodeAsync(plainText);
      }

      public async Task StockUpdateToProductAsync(string productId, int stock)
      {
           Product product = await _productReadRepository.GetByIdAsync(productId);
         if (product == null)
                throw new Exception("Product not found");

            product.Stock = stock;
            await _productWriteRepository.SaveAsync();
        
      }
   }
}