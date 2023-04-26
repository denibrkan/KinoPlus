using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class SeatsController : BaseController<Seat, SeatDto, BaseSearchObject>
    {
        public SeatsController(ISeatService service, IMapper mapper) : base(service, mapper)
        {
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<SeatDto>>> Get([FromQuery] BaseSearchObject search)
        {
            return base.Get(search);
        }
    }
}
