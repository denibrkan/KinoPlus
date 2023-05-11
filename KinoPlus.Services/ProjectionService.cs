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
            else if (search.DateFrom != null && search.DateTo != null)
            {
                query = query.Where(p => p.StartsAt.Date >= search.DateFrom.Value.Date &&
                                         p.StartsAt.Date <= search.DateTo.Value.Date);
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

            if (insert.IsRecurring)
            {
                var recurring = new RecurringProjection
                {
                    WeekDayId = insert.WeekDayId!.Value,
                    StartingDate = insert.StartingDate!.Value,
                    EndingDate = insert.EndingDate!.Value,
                    ProjectionTime = insert.ProjectionTime!.Value.TimeOfDay,
                };

                await _context.AddAsync(recurring);
                await _context.SaveChangesAsync();

                entity.RecurringProjectionId = recurring.Id;
            }
        }

        public override async Task<Projection> InsertAsync(ProjectionInsertObject insert)
        {
            var projection = _mapper.Map<Projection>(insert);

            await BeforeInsert(insert, projection);

            var movie = await _context.Movies.SingleAsync(m => m.Id == insert.MovieId);

            Tuple<int, int> startingTime = Tuple.Create(insert.ProjectionTime!.Value.Hour, insert.ProjectionTime!.Value.Minute);

            var projectionDates = new List<DateTime>();

            if (projection.RecurringProjectionId != null)
            {
                //find projection dates using starting date and day of week
                var comparingDate = insert.StartingDate;
                do
                {
                    if (((int)comparingDate!.Value.DayOfWeek) == insert.WeekDayId - 1)
                    {
                        projectionDates.Add(comparingDate.Value);
                    }

                    comparingDate = comparingDate.Value.AddDays(1);
                } while (comparingDate <= insert.EndingDate);
            }
            else
            {
                projectionDates.Add(insert.ProjectionDate!.Value);
            }

            foreach (var date in projectionDates)
            {
                var startsAtDate = new DateTime(date.Year, date.Month, date.Day, startingTime.Item1, startingTime.Item2, 0);
                var endsAtDate = startsAtDate.AddMinutes(movie.Duration);

                foreach (var locationHall in insert.Locations)
                {
                    _context.Projections.Add(
                        new Projection
                        {
                            MovieId = projection.MovieId,
                            ProjectionTypeId = projection.ProjectionTypeId,
                            Price = projection.Price,
                            StartsAt = startsAtDate,
                            EndsAt = endsAtDate,
                            RecurringProjectionId = projection.RecurringProjectionId,
                            LocationId = locationHall.LocationId!.Value,
                            HallId = locationHall.HallId!.Value,
                        });
                }
            }

            await _context.SaveChangesAsync();

            return projection;
        }
    }
}
