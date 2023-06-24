using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Features.Queries.ProductImage
{
   public class GetAllProductImageQueryHandle : IRequestHandler<GetAllProductImageQueryRequest,List<GetAllProductImageQueryResponse>>
   {

      readonly private  IProductReadRepository  _productReadRepository;
      readonly private IConfiguration _configuration;


      public GetAllProductImageQueryHandle(IProductReadRepository productReadRepository , IConfiguration configuration)
      {
         _configuration=configuration;
         _productReadRepository=productReadRepository;
      }
      
      public async Task<List<GetAllProductImageQueryResponse>> Handle(GetAllProductImageQueryRequest request, CancellationToken cancellationToken)
      {
      E::Product? product = await  _productReadRepository.Table.Include(p=>p.ProductImages)
                                        .FirstOrDefaultAsync(p=>p.id==Guid.Parse(request.Id));

     
     return   product.ProductImages.Select(p=> new GetAllProductImageQueryResponse{
     //Path=$"{_configuration["BaseStorageUrl"]}/{p.Path}",
       //Path= p.Path,
     Path=$"{_configuration["LocalStorageUrl"]}/{p.Path}",
    
      FileName= p.FileName,
      id= p.id}).ToList();
    
           

      }
   }
}