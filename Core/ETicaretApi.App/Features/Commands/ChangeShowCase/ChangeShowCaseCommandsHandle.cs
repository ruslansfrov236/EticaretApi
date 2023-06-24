using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Repository.ProductImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.App.Features.Commands.ChangeShowCase
{
   public class ChangeShowCaseCommandsHandle : IRequestHandler<ChangeShowCaseCommandsRequest, ChangeShowCaseCommandsResponse>
   {
      readonly private  IProductImageWriteRepository _productImage ;

      public ChangeShowCaseCommandsHandle(IProductImageWriteRepository productImage )
      {
        _productImage=productImage;
      }
      public async Task<ChangeShowCaseCommandsResponse> Handle(ChangeShowCaseCommandsRequest request, CancellationToken cancellationToken)
      {

         var query= _productImage.Table
                        .Include(p=>p.Product)
                        .SelectMany(p=>p.Product , (pif , p)=> new{
                            pif,
                             p
                        });
        var data = await  query.FirstOrDefaultAsync(p=>p.p.id==Guid.Parse(request.ProductId) && p.pif.ShowCase);


        if(data!=null)
        data.pif.ShowCase=false;
      var image=   await   query.FirstOrDefaultAsync(p=>p.pif.id==Guid.Parse(request.ImageId));
      
      if(image!=null)
       image.pif.ShowCase=true;

       await _productImage.SaveAsync();
        return new ();
         
      }
   }
}