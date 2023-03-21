using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class UsersController : BaseCRUDController<User, UserDto, UserInsertObject, UserUpdateObject, BaseSearchObject>
    {
        public UsersController(IUserService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
