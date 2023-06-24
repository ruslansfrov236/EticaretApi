using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ETicaretApi.App.Abstractions.Services.Configurations;
using ETicaretApi.App.Consts;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationController:ControllerBase
    {
        readonly private IApplicationService  _applicationService;

        public ApplicationController(IApplicationService  applicationService)
        {
            _applicationService=applicationService;
        }

        [HttpGet]
         
       
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConsts.Application,ActionType=ActionType.Reading , Definition ="Get Action Defintions Endpoint")]
        public IActionResult GetActionDefintionsEndpoint(){
         var data =    _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));

            return Ok(data);
        }
    }
}