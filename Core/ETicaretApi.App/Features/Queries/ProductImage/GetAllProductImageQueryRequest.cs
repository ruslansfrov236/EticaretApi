using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace ETicaretApi.App.Features.Queries.ProductImage
{
    public class GetAllProductImageQueryRequest:IRequest<List<GetAllProductImageQueryResponse>>
    {
        public string Id {get; set;}
    }
}