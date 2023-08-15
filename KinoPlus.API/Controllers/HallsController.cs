using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class HallsController : BaseController<Hall, HallDto, HallSearchObject>
    {
        public HallsController(IHallService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
