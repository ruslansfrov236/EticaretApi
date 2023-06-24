using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using MediatR;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Features.Commands.Product.DeleteProduct
{
   public class DeleteProductCommonHandle : IRequestHandler<DeleteProductCommonRequest, DeleteProductCommonResponse>
   {
         readonly private IProductReadRepository _productReadRepository;
         readonly private IProductWriteRepository _productWriteRepository;


       public DeleteProductCommonHandle(IProductReadRepository productReadRepository ,IProductWriteRepository productWriteRepository)
       {
         _productReadRepository=productReadRepository;
         _productWriteRepository=productWriteRepository;
       }
    
      public async Task<DeleteProductCommonResponse> Handle(DeleteProductCommonRequest request, CancellationToken cancellationToken)
      { 

        E:: Product product = await _productReadRepository.GetByIdAsync(request.Id);

            _productWriteRepository.Remove(product);
    await _productWriteRepository.SaveAsync();

        return new (){};
      }
   }
}