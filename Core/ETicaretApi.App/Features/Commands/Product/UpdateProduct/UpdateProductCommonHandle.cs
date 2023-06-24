using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using MediatR;
using Microsoft.Extensions.Logging;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Features.Commands.Product.UpdateProduct
{
   public class UpdateProductCommonHandle : IRequestHandler<UpdateProductCommonRequest, UpdateProductCommonResponse>
   {
  
     readonly private  IProductReadRepository _productReadRepository;
     readonly private IProductWriteRepository _productWriteRepository;
     public UpdateProductCommonHandle(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository)
     {
      _productReadRepository=productReadRepository;
      _productWriteRepository=productWriteRepository;

     }
    
      public async    Task<UpdateProductCommonResponse> Handle(UpdateProductCommonRequest request, CancellationToken cancellationToken)
      {
         E:: Product? product = await _productReadRepository.GetByIdAsync(request.Id);

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            await _productWriteRepository.SaveAsync();
       
            return new(){
               
            };
      }
   }
}