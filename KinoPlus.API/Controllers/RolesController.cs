using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class RolesController : BaseController<Role, RoleDto, BaseSearchObject>
    {
        public RolesController(IRoleService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}