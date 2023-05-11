using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class WeekDaysController : BaseController<WeekDay, WeekDayDto, BaseSearchObject>
    {
        public WeekDaysController(IWeekDayService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
