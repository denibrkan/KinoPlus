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
        private readonly IMapper _mapper;

        public ProjectionService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IQueryable<Projection> AddInclude(IQueryable<Projection> query, ProjectionSearchObject? search)
        {
            query = query
                .Include(p => p.Movie)
                .Include(p => p.ProjectionType)
                .Include(p => p.Location.City)
                .Include(p => p.Hall)
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
                query = query.Where(p => p.LocationId == search.LocationId);
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
            var projection = _mapper.Map<Projection>(insert);

            await BeforeInsert(insert, projection);

            foreach (var locationHall in insert.Locations)
            {
                _context.Projections.Add(
                    new Projection
                    {
                        MovieId = projection.MovieId,
                        ProjectionTypeId = projection.ProjectionTypeId,
                        Price = projection.Price,
                        StartsAt = projection.StartsAt,
                        EndsAt = projection.EndsAt,
                        RecurringProjectionId = projection.RecurringProjectionId,
                        LocationId = locationHall.LocationId!.Value,
                        HallId = locationHall.HallId!.Value,
                    });
            }

            await _context.SaveChangesAsync();

            return projection;
        }
    }
}
