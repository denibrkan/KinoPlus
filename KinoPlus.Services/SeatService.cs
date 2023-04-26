using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class SeatService : BaseService<Seat, BaseSearchObject>, ISeatService
    {
        public SeatService(KinoplusContext context) : base(context)
        {

        }
    }
}
