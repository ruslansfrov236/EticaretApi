

namespace ETicaretApi.App.Abstractions.Services
{
    public interface IRoleService
    {
         (object, int)  GetAllRoles( int page ,int size);
        Task<(string id , string name)>GetByIdRoles(string id );
        Task<bool> CreateRole(   string name);
        Task<bool> DeleteRole(string id);
        Task<bool> UpdatedRole(string id , string name);
    }
}