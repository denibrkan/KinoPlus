using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class LocationService : BaseCRUDService<Location, LocationUpsertObject, LocationUpsertObject, LocationSearchObject>, ILocationService
    {
        private readonly KinoplusContext _context;

        public LocationService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<Location?> GetByIdAsync(int id)
        {
            var query = _context.Locations.AsQueryable();

            query = AddInclude(query, null);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public override IQueryable<Location> AddInclude(IQueryable<Location> query, LocationSearchObject? search)
        {
            base.AddInclude(query, search);

            query = query
                .Include(l => l.City)
                .ThenInclude(c => c.Country)
                .Include(l => l.LocationHalls)
                .ThenInclude(lh => lh.Hall)
                .Include(l => l.LocationProjectionTypes)
                .ThenInclude(lpt => lpt.ProjectionType);

            return query;
        }

        public override IQueryable<Location> AddFilter(IQueryable<Location> query, LocationSearchObject search)
        {
            base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search.NameFTS))
            {
                query = query.Where(l => l.Name.Contains(search.NameFTS));
            }

            return query;
        }

        public override IQueryable<Location> AddSorting(IQueryable<Location> query, LocationSearchObject search)
        {
            query = query.OrderBy(l => l.Name);

            return query;
        }

        public async override Task<Location> InsertAsync(LocationUpsertObject insert)
        {
            var location = await base.InsertAsync(insert);

            InsertRelatedEntities(insert, location.Id);

            await _context.SaveChangesAsync();

            return (await GetByIdAsync(location!.Id))!;
        }

        public async override Task<Location> UpdateAsync(int id, LocationUpsertObject update)
        {
            await base.UpdateAsync(id, update);

            var location = await GetByIdAsync(id);

            _context.RemoveRange(location!.LocationProjectionTypes);
            _context.RemoveRange(location.LocationHalls);

            InsertRelatedEntities(update, location.Id);

            await _context.SaveChangesAsync();

            return (await GetByIdAsync(location.Id))!;
        }

        private void InsertRelatedEntities(LocationUpsertObject insert, int locationId)
        {
            foreach (var item in insert.ProjectionTypeIds)
            {
                _context.LocationProjectionTypes.Add(
                    new LocationProjectionType
                    {
                        LocationId = locationId,
                        ProjectionTypeId = item
                    }
                );
            }
            foreach (var item in insert.HallIds)
            {
                _context.LocationHalls.Add(
                    new LocationHall
                    {
                        LocationId = locationId,
                        HallId = item
                    }
                );
            }
        }
    }
}
