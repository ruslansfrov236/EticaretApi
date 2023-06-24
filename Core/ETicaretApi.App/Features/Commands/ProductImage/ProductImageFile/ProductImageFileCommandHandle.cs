using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Storage;
using ETicaretApi.App.Repository.Product;
using ETicaretApi.App.Repository.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using E=ETicaretApi.Domain.Entity;

namespace ETicaretApi.App.Features.Commands.ProductImage.ProductImageFile
{
   public class ProductImageFileCommandHandle : IRequestHandler<ProductImageFileCommandRequest, ProductImageFileCommandResponse>
   {
      readonly private IProductImageWriteRepository _productImageWriteRepository;
      readonly private IProductReadRepository _productReadRepository;
      readonly private IStorageService _storageService;
      public ProductImageFileCommandHandle(IProductReadRepository productReadRepository ,IStorageService storageService ,IProductImageWriteRepository productImageWriteRepository)
      {
         _productReadRepository=productReadRepository;
         _storageService=storageService;
         _productImageWriteRepository=productImageWriteRepository;
         
      }
      public async  Task<ProductImageFileCommandResponse> Handle(ProductImageFileCommandRequest request, CancellationToken cancellationToken)
      {
          
     List<(string fileName , string pathOrContainerName)> result =
           await  _storageService.UploadAsync("photo-images" , request.Files);
          
         E::Product product = await _productReadRepository.GetByIdAsync(request.Id);
         
          await   _productImageWriteRepository.AddRangeAsync(result.Select(d=>new E::ProductImage{
                Path=d.pathOrContainerName,
                FileName=d.fileName,
                Storage=_storageService.StorageName,
                Product=new List<E::Product>(){product}
            }).ToList());
            await _productImageWriteRepository.SaveAsync();
            return new();
           
  
      }
   }
}