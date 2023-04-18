using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class LocationsController : BaseCRUDController<Location, LocationDto, LocationInsertObject, LocationInsertObject, BaseSearchObject>
    {

        public LocationsController(ILocationService service, IMapper mapper) : base(service, mapper)
        {
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<LocationDto>>> Get([FromQuery] BaseSearchObject search)
        {
            return base.Get(search);
        }

    }
}
