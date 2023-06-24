using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Features.Queries.Basket.GetBasketItem;
using MediatR;

namespace ETicaretApi.App.Features.Queries.Basket.GetBaskettem
{
    public class GetBasketItemQueryRequest:IRequest<List<GetBasketItemQueryResponse>>
    {
       
    }
}