using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicaretApi.App.DTOs.User;
using ETicaretApi.Domain.Entity.Identity;

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateAsync(CreateUser model);
        Task<bool>  UpdateRefreshToken (string refreshToken, AppUser user, DateTime refreshTokenDate ,int addOnAccessTokenDate);
       Task UpdatedPassword(string userId , string resetToken , string newPassword);
       Task<List<ListUser>> GetAllUsersAsync(int page, int size);
       int TotalUsersCount {get;}
       Task AssignRoleToUserAsync( string userId , string[] Roles);
       Task<string[]> GetRoleToUserAsync( string userIdOrName);
       Task<bool> AssignRoleDeleteUser(string userId);
       Task<bool> HasRolePermissionToEndpointAsync( string name , string code );
   
    }
}