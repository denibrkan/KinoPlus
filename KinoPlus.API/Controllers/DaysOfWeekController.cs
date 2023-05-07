using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class DaysOfWeekController : BaseController<Services.Database.DayOfWeek, DayOfWeekDto, BaseSearchObject>
    {
        public DaysOfWeekController(IDayOfWeekService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
