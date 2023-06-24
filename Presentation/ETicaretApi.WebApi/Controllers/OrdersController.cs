using ETicaretApi.App.Consts;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Enums;
using ETicaretApi.App.Features.Commands.Orders.CompletedOrder;
using ETicaretApi.App.Features.Commands.Orders.OrderCreate;
using ETicaretApi.App.Features.Queries.Order.GetAllOrders;
using ETicaretApi.App.Features.Queries.Order.GetByIdOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {   
        readonly private IMediator _mediator;
       
        public OrdersController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Orders , ActionType =ActionType.Reading , Definition ="Get All Orders")]
      
        public async Task<ActionResult> GetAllOrders([FromQuery]GetAllOrdersQueriesRequest getAllOrdersQueriesRequest){
          GetAllOrdersQueriesResponse response = await _mediator.Send(getAllOrdersQueriesRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Orders , ActionType =ActionType.Reading , Definition ="Get By Id Orders")]
        public async Task<ActionResult> GetByIdOrders([FromRoute] GetByIdOrderQueriesRequest getByIdOrderQueriesRequest){
            GetByIdOrderQueriesResponse response =await _mediator.Send(getByIdOrderQueriesRequest);

            return Ok(response);
        }
        [HttpPost]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Orders , ActionType =ActionType.Writing , Definition ="Post")]
        public async Task <ActionResult> Post (OrderCreateCommandsRequest  orderCreateCommandsRequest){
            OrderCreateCommandsResponse response = await  _mediator.Send(orderCreateCommandsRequest);
            return Ok(response);
        }

        [HttpGet("completed-order/{id}")]
        [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Orders , ActionType =ActionType.Updating , Definition ="Complete Order")]
      
        public async Task<ActionResult> CompleteOrder([FromRoute] CompletedOrderCommandsRequest completedOrderCommandsRequest){
          
          CompletedOrderCommandsResponse response = await _mediator.Send(completedOrderCommandsRequest);
            return Ok(response);
        }
    }
}
