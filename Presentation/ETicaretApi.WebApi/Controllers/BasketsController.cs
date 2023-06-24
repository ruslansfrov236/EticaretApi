using ETicaretApi.App.Consts;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Enums;
using ETicaretApi.App.Features.Commands.Basket.AddItemToBasket;
using ETicaretApi.App.Features.Commands.Basket.DeleteBasketItem;
using ETicaretApi.App.Features.Commands.Basket.UpdatedBasketItem;
using ETicaretApi.App.Features.Queries.Basket.GetBasketItem;
using ETicaretApi.App.Features.Queries.Basket.GetBaskettem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {

        readonly private IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Baskets , ActionType =ActionType.Reading , Definition ="Get Basket Items")]
        public async Task<ActionResult> GetBasketItems([FromQuery] GetBasketItemQueryRequest getBasketItemQueryRequest)
        {

            List<GetBasketItemQueryResponse> response = await _mediator.Send(getBasketItemQueryRequest);
            return Ok(response);
        }
        [HttpDelete("{BasketItemId}")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Baskets , ActionType =ActionType.Deleting , Definition ="Delete To Basket Item")]
        public async Task<ActionResult> DeleteToBasketItem([FromRoute] DeleteBasketItemCommandRequest deleteBasketItemCommandRequest)
        {

            DeleteBasketItemCommandResponse response = await _mediator.Send(deleteBasketItemCommandRequest);
            return Ok(response);
        }
        [HttpPost]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Baskets , ActionType =ActionType.Writing , Definition ="Add Item To Basket")]
        
        public async Task<ActionResult> AddItemToBasket(AddItemBasketCommandRequest addItemBasketCommandRequest)
        {

            AddItemBasketCommandResponse response = await _mediator.Send(addItemBasketCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Baskets , ActionType =ActionType.Updating , Definition ="Updated To Basket")]
        public async Task<ActionResult> UpdatedToBasket(UpdateBasketItemCommandRequest updateBasketItemCommandRequest)
        {

            UpdateBasketItemCommandResponse response = await _mediator.Send(updateBasketItemCommandRequest);

            return Ok(response);
        }
    }
}
