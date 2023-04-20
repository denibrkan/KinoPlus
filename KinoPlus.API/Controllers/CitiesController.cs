using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class CitiesController : BaseController<City, CityDto, BaseSearchObject>
    {
        public CitiesController(ICityService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
