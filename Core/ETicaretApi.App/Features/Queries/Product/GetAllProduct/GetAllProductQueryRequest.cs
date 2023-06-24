using ETicaretApi.App.RequestParametrs;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Product.GetAllProduct
{
   public class GetAllProductQueryRequest:IRequest<GelAllProductQueryResponse>
     {
   //     public  Pagination? Pagination {get; set;}
         public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}