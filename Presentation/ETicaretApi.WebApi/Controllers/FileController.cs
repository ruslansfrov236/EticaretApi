using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController:ControllerBase
    {
            readonly private  IConfiguration _configuration;

     public FileController(IConfiguration configuration)
     {
        _configuration=configuration;
     }
    
     
        [HttpGet("GetBaseStorageUrl")]
        public ActionResult GetBaseStorageUrl(){
             return Ok(new {
            Url=_configuration["LocalStorageUrl"]
             });
        }

        
        [HttpGet(" GetAzureStorageUrl")]
        public ActionResult GetAzureStorageUrl(){


          return Ok (new{
            Url= _configuration["BaseStorageUrl"]
          });
        }
    }
}