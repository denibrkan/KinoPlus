using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class DayOfWeekService : BaseService<Database.DayOfWeek, BaseSearchObject>, IDayOfWeekService
    {
        public DayOfWeekService(KinoplusContext context) : base(context)
        {

        }
    }
}
