using ETicaretApi.App.RequestParametrs;
using ETicaretApi.App.Repository.Customer;
using ETicaretApi.App.Repository.Order;
using ETicaretApi.App.Repository.Product;

using ETicaretApi.App.ViewModels.Products;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ETicaretApi.App.Repository.InvoiceFile;
using ETicaretApi.App.Repository.ProductImageFile;
using ETicaretApi.App.Repository.File;
using ETicaretApi.App.Abstractions.Storage;
using ETicaretApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using ETicaretApi.App.Features.Queries.Product.GetAllProduct;
using ETicaretApi.App.Features.Commands.Product.CreateProduct;
using ETicaretApi.App.Features.Queries.Product.GetByIdProduct;
using ETicaretApi.App.Features.Commands.Product.UpdateProduct;
using ETicaretApi.App.Features.Commands.Product.DeleteProduct;
using ETicaretApi.App.Features.Commands.ProductImage.ProductImageFile;
using ETicaretApi.App.Features.Commands.ProductImage.DeleteImageFile;
using ETicaretApi.App.Features.Queries.ProductImage;
using Microsoft.AspNetCore.Authorization;
using ETicaretApi.App.Features.Commands.ChangeShowCase;
using ETicaretApi.App.CustomAtributes;
using ETicaretApi.App.Consts;
using ETicaretApi.App.Enums;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.Features.Commands.Product.UpdateStockQrCodeToProduct;

namespace ETicaretApi.WebApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
    public class ProductsController : ControllerBase
    {

       
       
       readonly private  IMediator _mediator;
       readonly private ILogger<ProductsController> _logger;
       readonly private IProductService _productService;


      public ProductsController(IMediator mediator, ILogger<ProductsController> logger, IProductService productService = null)
      {
         _mediator = mediator;
         _logger = logger;
         _productService = productService;
      }





      [HttpGet]  
      public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest  getAllProductQueryRequest   )
        {
        GelAllProductQueryResponse response   =await  _mediator.Send(getAllProductQueryRequest);
         return Ok (response);
        }
      [HttpGet("qrcode/{productId}")]  
      public async Task<IActionResult> GetQrCodeToProduct([FromRoute]    string productId)
        {
        var data =  await _productService.ProductQrCodeAsync(productId);
         return File(data, "image/png");
        }
         [HttpPut("qrcode")]  
      public async Task<IActionResult> UpdateStockQrCodeToProduct( UpdateStockQrCodeToProductCommandsRequest updateStockQrCodeToProductCommandsRequest)
        {
           UpdateStockQrCodeToProductCommandsResponse response = await _mediator.Send(updateStockQrCodeToProductCommandsRequest);
           return Ok(response);
        }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {

          GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);

        }

    [HttpPost]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Writing , Definition ="Post")]
    public async Task<IActionResult> Post(  CreateProductsCommandsRequest  createProductsCommandsRequest)
        {
           
     
           CreateProductCommonResponse response = await   _mediator.Send(createProductsCommandsRequest);
            return StatusCode((int)HttpStatusCode.Created);

        }

    [HttpPut]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Updating , Definition ="Put")]
    public async Task<ActionResult>Put([FromBody] UpdateProductCommonRequest updateProductCommonRequest)
        {

            UpdateProductCommonResponse response =  await _mediator.Send(updateProductCommonRequest);
            return Ok(response);
        }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Writing , Definition ="Upload")]
    public async Task <ActionResult> Upload([FromQuery , FromForm] ProductImageFileCommandRequest _productImageFileCommandRequest){

          _productImageFileCommandRequest.Files=Request.Form.Files;
          ProductImageFileCommandResponse response = await _mediator.Send(_productImageFileCommandRequest);

          return Ok(response);
      }

    [HttpDelete("{id}")]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Deleting , Definition ="Delete")]
    public async Task<ActionResult<Product>> Delete([FromRoute] DeleteProductCommonRequest   deleteProductCommonRequest)
        {
   
          DeleteProductCommonResponse response = await _mediator.Send(deleteProductCommonRequest);

          return Ok();
        } 


    [HttpGet("[action]/{id}")]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Reading , Definition ="Get Product Images")]
    public async  Task<ActionResult> GetProductImages([FromRoute] GetAllProductImageQueryRequest getAllProductImageQueryRequest ){
    
       List<GetAllProductImageQueryResponse> response = await _mediator.Send(getAllProductImageQueryRequest);

       return   Ok(response);
    } 


    [HttpDelete("deleteproductimages/{Id}")]
    [Authorize(AuthenticationSchemes="Admin")]
    [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Deleting , Definition ="Delete Product Images")]
    public async Task <ActionResult> DeleteProductImages([FromRoute]  DeleteImageFileCommandRequest deleteImageFileCommandRequest , [FromQuery] string imageId){
    
      deleteImageFileCommandRequest.ImageId=imageId;
      DeleteImageFileCommandResponse response = await _mediator.Send(deleteImageFileCommandRequest);
     return  Ok(response);

     
      }

       [HttpGet ("ChangeShowCase")]
       [Authorize(AuthenticationSchemes="Admin")]
           [AuthorizeDefinitionAttribute(Menu = AuthorizeDefinitionConsts.Products , ActionType =ActionType.Updating, Definition ="Change Show Case")]
      public async Task <ActionResult> ChangeShowCase([FromQuery]ChangeShowCaseCommandsRequest  changeShowCaseCommandsRequest ){

      ChangeShowCaseCommandsResponse  response = await _mediator.Send(changeShowCaseCommandsRequest);
          return Ok(response);
      }
}



   
}