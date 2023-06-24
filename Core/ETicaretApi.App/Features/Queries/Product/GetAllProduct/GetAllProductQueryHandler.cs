
using ETicaretApi.App.Repository.Product;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETicaretApi.App.Features.Queries.Product.GetAllProduct
{
   public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest,  GelAllProductQueryResponse>
   {
        readonly private IProductReadRepository _productReadRepository;
        readonly private ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository , ILogger<GetAllProductQueryHandler> logger)
        {
            _productReadRepository=productReadRepository;
            _logger=logger;
        }

      public async Task<GelAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
      {
           _logger.LogInformation("Get all products");
        
            var totalCount = _productReadRepository.GetAll(false).Count();
            
            var products = _productReadRepository.GetAll(false)
            .Include(p=>p.ProductImages)
            .Select(p => new
            {
                p.id,
                p.Name,
                p.Stock,
                p.Price,
                p.CreatedDate,
                p.UpdatedDate,
                p.ProductImages

            }).Skip(request.Page * request.Size).Take(request.Size).ToList();
         
            return new() {
              
               Products=products,
               TotalCount=totalCount
             };

             
      }
   }
}
