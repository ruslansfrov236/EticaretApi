using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Hubs;
using ETicaretApi.App.Repository.Product;
using MediatR;

namespace ETicaretApi.App.Features.Commands.Product.CreateProduct
{
   public class CreateProductCommonHandle : IRequestHandler<CreateProductsCommandsRequest, CreateProductCommonResponse>
   {


    readonly private  IProductWriteRepository _productWriteRepository;
   readonly private IProductHubService _productHubService;
    public CreateProductCommonHandle( IProductWriteRepository productWriteRepository ,IProductHubService productHubService)
    {
        _productWriteRepository= productWriteRepository;
        _productHubService=productHubService;
    }
      public async Task<CreateProductCommonResponse> Handle(CreateProductsCommandsRequest? request, CancellationToken cancellationToken)
      {
            var product=    await _productWriteRepository.AddAsync(new()
            {
               
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock


            });
            await _productWriteRepository.SaveAsync();
            if(product){
                await _productHubService.ProductAddedMessageAsync($"{request.Name} creating");
            }else{
                      await _productHubService.ProductAddedMessageAsync($" erorrs");
            }

      

            return new(){};
      }
   }
}