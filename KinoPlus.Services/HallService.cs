using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class HallService : BaseService<Hall, BaseSearchObject>, IHallService
    {
        public HallService(KinoplusContext context) : base(context)
        {

        }
    }
}
