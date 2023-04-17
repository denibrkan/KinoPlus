using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class LocationService : BaseCRUDService<Location, LocationInsertObject, LocationInsertObject, BaseSearchObject>, ILocationService
    {
        public LocationService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Location> AddInclude(IQueryable<Location> query, BaseSearchObject? search)
        {
            base.AddInclude(query, search);

            query = query
                .Include(l => l.City)
                .Include(l => l.LocationHalls)
                .ThenInclude(lh => lh.Hall);

            return query;
        }

    }
}
