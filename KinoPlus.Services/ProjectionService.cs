using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class ProjectionService : BaseCRUDService<Projection, ProjectionInsertObject, ProjectionInsertObject, ProjectionSearchObject>, IProjectionService
    {
        public ProjectionService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Projection> AddInclude(IQueryable<Projection> query, ProjectionSearchObject? search)
        {
            query = query
                .Include(p => p.Movie)
                .Include(p => p.ProjectionType)
                .Include(p => p.ProjectionLocations).ThenInclude(pl => pl.Location);

            return query;
        }

        public override IQueryable<Projection> AddFilter(IQueryable<Projection> query, ProjectionSearchObject search)
        {
            if (search.Date != null)
            {
                query = query.Where(p => p.StartsAt.Date == search.Date.Value.Date);
            }

            if (search.LocationId != null)
            {
                query = query.Where(p => p.ProjectionLocations.Any(pl => pl.LocationId == search.LocationId));
            }

            return query;
        }

    }
}
