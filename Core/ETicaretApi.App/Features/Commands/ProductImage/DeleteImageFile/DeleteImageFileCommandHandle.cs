using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using E=ETicaretApi.Domain.Entity;
namespace ETicaretApi.App.Features.Commands.ProductImage.DeleteImageFile
{
   public class DeleteImageFileCommandHandle : IRequestHandler<DeleteImageFileCommandRequest, DeleteImageFileCommandResponse>
   {

       readonly private IProductReadRepository _productReadRepository;
       readonly private IProductWriteRepository _productWriteRepository;

       public DeleteImageFileCommandHandle(IProductReadRepository productReadRepository , IProductWriteRepository productWriteRepository)
       {
         _productReadRepository=productReadRepository;
         _productWriteRepository=productWriteRepository;
       }
      public async  Task<DeleteImageFileCommandResponse> Handle(DeleteImageFileCommandRequest request, CancellationToken cancellationToken)
      {
          E::Product? product = await  _productReadRepository.Table.Include(p=>p.ProductImages)
                                        .FirstOrDefaultAsync(p=>p.id==Guid.Parse(request.Id));

  E::ProductImage? productImage=  product?.ProductImages?.FirstOrDefault(p=>p.id==Guid.Parse(request.ImageId));
   if(productImage!=null)
   
    product?.ProductImages?.Remove(productImage);
     await  _productWriteRepository.SaveAsync();

     return new ();
      }
   }
}