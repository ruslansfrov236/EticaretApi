using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.Features.Commands.AppUser.FacebookLogin;
using ETicaretApi.App.Features.Commands.AppUser.GoogleLogin;
using ETicaretApi.App.Features.Commands.AppUser.Login;
using ETicaretApi.App.Features.Commands.AppUser.PasswordReset;
using ETicaretApi.App.Features.Commands.AppUser.VeriftResetToken;
using ETicaretApi.App.Features.Commands.RefreshTokenLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        readonly private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator=mediator;
        }
           [HttpPost("[action]")]
        public async Task <ActionResult> Login(LoginCommandsRequest loginCommandsRequest){
         LoginCommandsResponse response = await _mediator.Send(loginCommandsRequest);
            
            
            return Ok(response);
        }
        [HttpPost("refresh-token-login")]
        public async Task <ActionResult> RefreshTokenLogin([FromBody]RefreshTokenLoginCommandsRequest  refreshCommandsTokenRequest){
         RefreshTokenLoginCommandsResponse response = await _mediator.Send(refreshCommandsTokenRequest);
            
            
            return Ok(response);
        }
        [HttpPost("google-login")]
        public  async Task<ActionResult> GoogleLogin (GoogleLoginCommandRequest googleLoginCommandRequest){

            GoogleLoginCommandResponse response = await  _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("facebook-login")]
        public async Task <ActionResult> FacebookLogin(FacebookLoginCommandsRequest facebookLoginCommandsRequest){
           
           FacebookLoginCommandsResponse response = await _mediator.Send(facebookLoginCommandsRequest);
            return Ok(response);
        }

        [HttpPost ("password-reset")]
        public async Task <ActionResult> PasswordReset([FromBody]PasswordResetCommandRequest passwordResetCommandRequest){
           
           PasswordResetCommandResponse response = await _mediator.Send(passwordResetCommandRequest);
            return Ok(response);
        }

        [HttpPost ("verify-reset-token")]

        public async Task<ActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommandRequest   verifyResetTokenCommandRequest){
             VerifyResetTokenCommandResponse response= await _mediator.Send(verifyResetTokenCommandRequest);
         return Ok(response);
        }
    }
    }
