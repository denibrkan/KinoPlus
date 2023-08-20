using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class RoleService : BaseService<Role, BaseSearchObject>, IRoleService
    {
        public RoleService(KinoplusContext context) : base(context)
        {

        }
    }
}
