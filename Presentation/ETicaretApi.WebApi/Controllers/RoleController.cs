using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Consts;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Enums;
using ETicaretApi.App.Features.Commands.Role.CreateRole;
using ETicaretApi.App.Features.Commands.Role.DeleteRole;
using ETicaretApi.App.Features.Commands.Role.UpdatedRole;
using ETicaretApi.App.Features.Queries.Role.GetAllRole;
using ETicaretApi.App.Features.Queries.Role.GetByIdRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RoleController:ControllerBase
    { 
        readonly private IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet]
        [AuthorizeDefinitionAttribute (Menu = AuthorizeDefinitionConsts.Role, ActionType =ActionType.Reading , Definition ="Get Roles All") ]
        public async Task<IActionResult> GetRolesAsync([FromQuery]GetAllRoleQueriesRequest getAllRoleQueriesRequest){
            
            GetAllRoleQueriesResponse response =await _mediator.Send(getAllRoleQueriesRequest);
            return Ok(response);
        }
        [HttpGet("{id}")]
        [AuthorizeDefinitionAttribute (Menu = AuthorizeDefinitionConsts.Role,ActionType =ActionType.Reading , Definition ="Get Roles By Id") ]
       
        public  async Task<IActionResult> GetRoles([FromRoute] GetByidRolesQueriesRequest  getByidRolesQueriesRequest){
          
          GetByidRolesQueriesResponse response = await  _mediator.Send(getByidRolesQueriesRequest);
          
            return Ok(response );
        }
         [HttpPost()]
        [AuthorizeDefinitionAttribute (Menu = AuthorizeDefinitionConsts.Role,ActionType =ActionType.Writing , Definition ="Created Roles") ]
        public async Task<IActionResult>  CreatedRoles([FromBody]CreateRoleCommandsRequest  createRoleCommandsRequest){
         
          CreateRoleCommandsResponse response = await _mediator.Send(createRoleCommandsRequest);
        
            return Ok(response);
        }
        [HttpPut("{id}")]
         [AuthorizeDefinitionAttribute (Menu = AuthorizeDefinitionConsts.Role,ActionType =ActionType.Updating, Definition ="Updated Roles") ]
       
        public async Task<IActionResult>  UpdatedRoles([FromBody, FromRoute] UpdatedRoleCommandsRequest  updatedRoleCommandsRequest){
           UpdatedRoleCommandsResponse response = await  _mediator.Send(updatedRoleCommandsRequest);
            return Ok(response);
        }
         [HttpDelete("{id}")]
         [AuthorizeDefinitionAttribute (Menu = AuthorizeDefinitionConsts.Role,ActionType =ActionType.Deleting , Definition ="Deleted Roles") ]
       
        public async Task<IActionResult>  DeletedRoles([ FromRoute]DeleteRoleCommandsRequest deleteRoleCommandsRequest){
           
           DeleteRoleCommandsResponse response = await _mediator.Send(deleteRoleCommandsRequest);
            return Ok(response);
        }
    }
}