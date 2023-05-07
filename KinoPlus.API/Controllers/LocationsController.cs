using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class LocationsController : BaseCRUDController<Location, LocationDto, LocationUpsertObject, LocationUpsertObject, LocationSearchObject>
    {
        public LocationsController(ILocationService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
