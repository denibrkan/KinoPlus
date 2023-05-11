using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class WeekDayService : BaseService<WeekDay, BaseSearchObject>, IWeekDayService
    {
        public WeekDayService(KinoplusContext context) : base(context)
        {

        }
    }
}
