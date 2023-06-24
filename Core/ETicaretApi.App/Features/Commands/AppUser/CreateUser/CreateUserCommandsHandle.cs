using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.DTOs.User;
using ETicaretApi.App.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using E = ETicaretApi.Domain.Entity.Identity;
namespace ETicaretApi.App.Features.Commands.AppUser.CreateUser
{
   public class CreateUserCommandsHandle : IRequestHandler<CreateUserCommandsRequest, CreateUserCommandsResponse>
   {

      readonly private IUserService _userService;

      public CreateUserCommandsHandle(IUserService userService)
      {
         _userService=userService;
      }
      public async Task<CreateUserCommandsResponse> Handle(CreateUserCommandsRequest request, CancellationToken cancellationToken)
      {
           

        
       CreateUserResponse response=  await  _userService.CreateAsync(new(){

               Email=request.Email,
               NameSurname=request.NameSurname,
               Password=request.Password,
               UserName=request.UserName

             });


             return new (){
                Message=response.Message,
                Succeeded=response.Succeeded
             };
           
      }
   }
}