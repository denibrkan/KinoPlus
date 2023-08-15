using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class HallService : BaseService<Hall, HallSearchObject>, IHallService
    {
        public HallService(KinoplusContext context) : base(context)
        {

        }

        public override IQueryable<Hall> AddFilter(IQueryable<Hall> query, HallSearchObject search)
        {
            if (search.LocationId.HasValue)
            {
                query = query.Include(h => h.LocationHalls)
                    .Where(x => x.LocationHalls.Any(y => y.LocationId == search.LocationId.Value));
            }

            return query;
        }
    }
}
