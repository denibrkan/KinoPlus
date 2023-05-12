using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IUserService : ICRUDService<User, UserInsertObject, UserUpdateObject, UserSearchObject>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<List<Role>> GetRoles();
    }
}
