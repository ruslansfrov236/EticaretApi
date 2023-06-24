using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using MediatR;
using P = ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Features.Queries.Product.GetByIdProduct
{
  
   public class GetByIdProductQueryHandle : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
   {

      readonly private IProductReadRepository _productReadRepository;

    public GetByIdProductQueryHandle(IProductReadRepository productReadRepository)
    {
        _productReadRepository=productReadRepository;
    }

      public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
      {
        P:: Product product=   await _productReadRepository.GetByIdAsync(request.Id ,false);

            return new (){
             Name= product.Name,
             Price=product.Price,
             Stock=product.Stock


            };
      }
   }
}