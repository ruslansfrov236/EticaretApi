using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Enums;
using ETicaretApi.App.Features.Commands.AppUser.AssignRolUser;
using ETicaretApi.App.Features.Commands.AppUser.CreateUser;
using ETicaretApi.App.Features.Commands.AppUser.FacebookLogin;
using ETicaretApi.App.Features.Commands.AppUser.GoogleLogin;
using ETicaretApi.App.Features.Commands.AppUser.Login;
using ETicaretApi.App.Features.Commands.AppUser.PasswordUpdate;
using ETicaretApi.App.Features.Queries.Users.AppUser;
using ETicaretApi.App.Features.Queries.Users.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ETicaretApi.WebApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
    public class UserController:ControllerBase
    {
        readonly private IMediator _mediator;
        readonly private IMailService _mailService;

        public UserController(IMediator mediator, IMailService mailService)
        {
            _mediator=mediator;
            _mailService=mailService;
        }

        [HttpPost]
        public async Task <ActionResult> CreateUser(CreateUserCommandsRequest createUserCommandsRequest)
        {
          CreateUserCommandsResponse response = await _mediator.Send(createUserCommandsRequest);

           return Ok(response);
        }

       [HttpPost("update-password")]

       public async Task<ActionResult> PasswordUpdate(PasswordUpdateCommandsRequest passwordUpdateCommandsRequest){
         PasswordUpdateCommandsResponse response = await _mediator.Send(passwordUpdateCommandsRequest);
        return Ok(response);
       }

       [HttpGet]
       [Authorize(AuthenticationSchemes ="Admin")]
       [AuthorizeDefinition( Menu="Users" ,ActionType =ActionType.Reading , Definition ="Get All User")]
       public async Task<IActionResult> GetAllUser([FromQuery]GetAllUserQueriesRequest getAllUserQueriesRequest){
    
        GetAllUserQueriesResponse response =  await _mediator.Send(getAllUserQueriesRequest);
        return Ok(response);
       }

       [HttpGet("get-roles-to-user/{UserId}")]
       [Authorize(AuthenticationSchemes ="Admin")]
       [AuthorizeDefinition( Menu="Users" ,ActionType =ActionType.Reading , Definition ="Get Roles To User")]
       public async Task<IActionResult> GetRolesToUser([FromRoute]GetRolesToUserQueriesRequest  getRolesToUserQueriesRequest){
        GetRolesToUserQueriesResponse response = await _mediator.Send(getRolesToUserQueriesRequest);
       return Ok(response);
       }
       [HttpDelete("{UserId}")]
       [Authorize(AuthenticationSchemes ="Admin")]
       [AuthorizeDefinition( Menu="Users" ,ActionType =ActionType.Reading , Definition ="Get Roles Delete User")]
       public async Task<IActionResult> GetRolesDeleteUser([FromRoute]GetRolesToUserQueriesRequest  getRolesToUserQueriesRequest){
        GetRolesToUserQueriesResponse response = await _mediator.Send(getRolesToUserQueriesRequest);
       return Ok(response);
       }
      [HttpPost("assign-role-to-user")]
      [Authorize(AuthenticationSchemes ="Admin")]
      [AuthorizeDefinition( Menu="Users" ,ActionType =ActionType.Reading , Definition ="Get All User")]
      public async Task <ActionResult> AssignRoleToUser(AssignRolUserCommandsRequest  assignRolUserCommandsRequest){
      AssignRolUserCommandsResponse response = await _mediator.Send(assignRolUserCommandsRequest);
        return Ok(response);
      }
   
    }
}