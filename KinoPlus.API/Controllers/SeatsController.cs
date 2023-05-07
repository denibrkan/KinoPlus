using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class SeatsController : BaseController<Seat, SeatDto, BaseSearchObject>
    {
        public SeatsController(ISeatService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
