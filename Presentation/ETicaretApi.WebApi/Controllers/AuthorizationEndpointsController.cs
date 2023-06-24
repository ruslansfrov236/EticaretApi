using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Features.Commands.AuthorizeEndpoints.AssignRole;
using ETicaretApi.App.Features.Queries.AuthorizeEndpoints.GetRolesToEndpoint;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController:ControllerBase
    {
         readonly private IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost("Get-Roles-To-Endpoint")]
        public async Task<ActionResult> GetRolesToEndpoint([FromBody]GetRolesToEndpointQueriesRequest  getRolesToEndpointQueriesRequest){
           GetRolesToEndpointQueriesResponse response = await _mediator.Send(getRolesToEndpointQueriesRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task <IActionResult> Post(AssignRoleCommandsRequest   assignRoleCommandsRequest){
          assignRoleCommandsRequest.type=typeof(Program);
          AssignRoleCommandsResponse response = await _mediator.Send(assignRoleCommandsRequest);
            return Ok();
        }
    }
}