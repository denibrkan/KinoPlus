using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class ProjectionService : BaseCRUDService<Projection, ProjectionInsertObject, ProjectionInsertObject, ProjectionSearchObject>, IProjectionService
    {
        private readonly KinoplusContext _context;

        public ProjectionService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override IQueryable<Projection> AddInclude(IQueryable<Projection> query, ProjectionSearchObject? search)
        {
            query = query
                .Include(p => p.Movie)
                .Include(p => p.ProjectionType)
                .Include(p => p.ProjectionLocations).ThenInclude(pl => pl.Location)
                .Include(p => p.ProjectionLocations).ThenInclude(pl => pl.Hall)
                .Include(p => p.Tickets);

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

            if (search.MovieId != null)
            {
                query = query.Where(p => p.MovieId == search.MovieId);
            }

            return query;
        }

        public override IQueryable<Projection> AddSorting(IQueryable<Projection> query, ProjectionSearchObject search)
        {
            query = query.OrderBy(x => x.StartsAt);

            return query;
        }

        public override async Task BeforeInsert(ProjectionInsertObject insert, Projection entity)
        {
            await base.BeforeInsert(insert, entity);
            var movie = await _context.Movies.SingleAsync(m => m.Id == insert.MovieId);

            entity.StartsAt = new DateTime(insert.ProjectionDate!.Value.Year, insert.ProjectionDate.Value.Month, insert.ProjectionDate.Value.Day, insert.StartsAt!.Value.Hour, insert.StartsAt.Value.Minute, 0);
            entity.EndsAt = entity.StartsAt.AddMinutes(movie.Duration);
        }

        public override async Task<Projection> InsertAsync(ProjectionInsertObject insert)
        {
            var insertedProjection = await base.InsertAsync(insert);

            foreach (var locationHall in insert.Locations)
            {
                _context.ProjectionLocations.Add(new ProjectionLocation
                {
                    ProjectionId = insertedProjection.Id,
                    LocationId = locationHall.LocationId!.Value,
                    HallId = locationHall.HallId!.Value,
                });
            }

            await _context.SaveChangesAsync();

            return insertedProjection;
        }
    }
}
