using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IUserService : ICRUDService<User, UserInsertObject, UserUpdateObject, BaseSearchObject>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<List<Role>> GetRoles();
    }
}
