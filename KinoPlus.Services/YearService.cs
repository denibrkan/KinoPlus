using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class YearService : BaseService<Year, BaseSearchObject>, IYearService
    {
        public YearService(KinoplusContext context) : base(context)
        {

        }
    }
}
