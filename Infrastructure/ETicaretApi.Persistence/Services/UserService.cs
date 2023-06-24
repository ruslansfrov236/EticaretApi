using ETicaretApi.App.Helpers;
using ETicaretApi.App.Abstractions.Services;
using ETicaretApi.App.DTOs.User;
using ETicaretApi.App.Exceptions;
using ETicaretApi.Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ETicaretApi.App.Repository.Endoint;
using ETicaretApi.Domain.Entity;

namespace ETicaretApi.Persistence.Services
{
   public class UserService : IUserService
   {
       readonly private UserManager<AppUser> _userManager;
       readonly private IEndpointReadRepository  _endpointReadRepository;
      public UserService(UserManager<AppUser> userManager, IEndpointReadRepository endpointReadRepository = null)
      {
         _userManager = userManager;
         _endpointReadRepository = endpointReadRepository;
      }

      public int TotalUsersCount => _userManager.Users.Count();

    public async Task<bool> AssignRoleDeleteUser(string userId)
{
    AppUser user = await _userManager.FindByIdAsync(userId);
    if (user != null)
    {
        // Get the user's current roles
        var userRoles = await _userManager.GetRolesAsync(user);

        // Remove the user from each role
        foreach (var roleName in userRoles)
        {
            await _userManager.RemoveFromRoleAsync(user, roleName);
        }

        return true;
    }
    return false;
}

      public async Task AssignRoleToUserAsync(string userId, string[] Roles)
      {
       AppUser user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
               var userRoles =await _userManager.GetRolesAsync(user);
               await   _userManager.RemoveFromRolesAsync(user , userRoles);
               await   _userManager.AddToRolesAsync(user, Roles);    
            }
      }

      public async Task<CreateUserResponse> CreateAsync(CreateUser model)
      {
           IdentityResult? result=  await  _userManager.CreateAsync(new(){
               Id=Guid.NewGuid().ToString(),
                UserName=model.UserName,
                NameSurname=model?.NameSurname,
                Email= model?.Email
           } , model?.Password);

           CreateUserResponse response = new(){Succeeded=result.Succeeded};
            if(result.Succeeded)
                response.Message="Account created successfully";
                else

                foreach (var error in result.Errors)
                {
                  response.Message+=$"{error.Code}-{error.Description}</br>";
                }
                  response.Message="Any error occurred while creating the account";
            
               return response;
      }

      public async Task<List<ListUser>> GetAllUsersAsync(int page, int size)
      {
           var Appusers=  await _userManager.Users.Skip(page*size).Take(size).ToListAsync();

         return Appusers.Select(user=> new ListUser{
            Id=user.Id,
            UserName=user.UserName,
            Email=user.Email,
            NameSurName= user.NameSurname,
            TwoFactorEnabled= user.TwoFactorEnabled


      }).ToList();
      }

      public async Task<string[]> GetRoleToUserAsync(string userIdOrName)
      {
        AppUser user = await _userManager.FindByIdAsync(userIdOrName);
         if(user==null)
            user=await _userManager.FindByNameAsync(userIdOrName);
        if(user!=null){
         var userRoles = await _userManager.GetRolesAsync(user);
         return  userRoles.ToArray();
        }

        throw new  NotUserException();
      }

      public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
      {
         var userRoles = await GetRoleToUserAsync(name);

         if(userRoles.Any())
            return false;
        Endpoint? endpoint=await  _endpointReadRepository.Table.Include(e=>e.Roles).FirstOrDefaultAsync(e=>e.Code==code);
          if(endpoint==null)
             return false;
         

          var endpointRoles=endpoint.Roles.Select(r=>r.Name);

          foreach (var userRole in userRoles)
          {
           foreach (var endpointRole in endpointRoles)
              if(userRole==endpointRole){
                 return true;
              }
          }
          return false;
      }

      public async Task UpdatedPassword(string userId, string resetToken, string newPassword)
      {
          AppUser user = await _userManager.FindByIdAsync(userId);
              if(user!=null)
            {
                  resetToken=  resetToken.UrlDecode();
               IdentityResult result=  await  _userManager.ResetPasswordAsync(user , resetToken , newPassword);

               if(result.Succeeded){
                  await _userManager.UpdateSecurityStampAsync(user);
               }else{
                   throw  new PasswordChangeFailedException();
               }
            }
      }

      public async Task<bool> UpdateRefreshToken( string refreshToken , AppUser user  , DateTime refreshTokenDate , int addOnAccessTokenDate)
      {
      
         if(user!=null){
            user.RefreshToken=refreshToken;
            user.RefreshTokenEndDate=refreshTokenDate.AddSeconds(addOnAccessTokenDate);

             await _userManager.UpdateAsync(user);
         }else{
           throw new NotFoundUserExceptions();
         }
      
         

          return true;
      }
   }
}