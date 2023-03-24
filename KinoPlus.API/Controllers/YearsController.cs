using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class YearsController : BaseController<Year, YearDto, BaseSearchObject>
    {
        public YearsController(IYearService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
