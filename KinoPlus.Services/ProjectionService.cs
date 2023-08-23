using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class ProjectionService : BaseService<Projection, ProjectionSearchObject>, IProjectionService
    {
        private readonly KinoplusContext _context;

        public ProjectionService(KinoplusContext context, IMapper mapper) : base(context)
        {
            _context = context;
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

        public async Task<List<Projection>> InsertProjectionsAsync(ProjectionInsertObject insert)
        {
            int? recurringId = null;
            var projectionDates = new List<DateTime>();

            if (insert.IsRecurring)
            {
                recurringId = await InsertRecurringProjectionAsync(insert);
                projectionDates = GetProjectionDates(insert);
            }
            else
            {
                projectionDates.Add(insert.ProjectionDate!.Value);
            }

            var movie = await _context.Movies.SingleAsync(m => m.Id == insert.MovieId);

            var projections = new List<Projection>();
            var projectionTime = insert.ProjectionTime!.Value;

            //insert projections by dates and locations
            foreach (var projectionDate in projectionDates)
            {
                var startsAt = projectionDate.Date.AddHours(projectionTime.Hour).AddMinutes(projectionTime.Minute);
                var endsAt = startsAt.AddMinutes(movie.Duration);

                foreach (var locationHall in insert.Locations)
                {
                    if (!await CheckProjectionOverlaping(startsAt, endsAt, locationHall.LocationId!.Value, locationHall.HallId!.Value))
                        throw new Exception("Postoji vremensko i lokacijsko preklapanje sa postojećim projekcijama. \n\nObratite pažnju na odabrane lokacije i dvorane projekcije. \n\nNapomena: Obavezni razmak između projekcija je 15 minuta!");

                    projections.Add
                    (
                        new Projection
                        {
                            MovieId = insert.MovieId!.Value,
                            ProjectionTypeId = insert.ProjectionTypeId!.Value,
                            Price = insert.Price!.Value,
                            StartsAt = startsAt,
                            EndsAt = endsAt,
                            RecurringProjectionId = recurringId,
                            LocationId = locationHall.LocationId!.Value,
                            HallId = locationHall.HallId!.Value,
                        }
                    );
                }
            }

            _context.Projections.AddRange(projections);
            await _context.SaveChangesAsync();

            return projections;
        }

        private async Task<int> InsertRecurringProjectionAsync(ProjectionInsertObject insert)
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

            return recurring.Id;
        }

        private List<DateTime> GetProjectionDates(ProjectionInsertObject insert)
        {
            var projectionDates = new List<DateTime>();

            //find projection dates using starting date and day of week
            var startDate = insert.StartingDate!.Value.Date;
            var endDate = insert.EndingDate!.Value.Date;
            do
            {
                if ((int)startDate.DayOfWeek == insert.WeekDayId - 1)
                {
                    projectionDates.Add(startDate);
                }

                startDate = startDate.AddDays(1);
            } while (startDate <= endDate);

            return projectionDates;
        }

        public async Task<Projection> UpdateAsync(int id, ProjectionUpdateObject updateObject)
        {
            var projection = _context.Projections.SingleOrDefault(p => p.Id == id);

            if (projection == null) throw new Exception($"Projekcija sa id: {id} ne postoji");
            var movie = _context.Movies.Single(m => m.Id == projection.MovieId);

            var startsAt = updateObject.StartsAt!.Value;
            var endsAt = startsAt.AddMinutes(movie.Duration);
            var hallId = updateObject.HallId!.Value;

            if (!await CheckProjectionOverlaping(startsAt, endsAt, projection.LocationId, hallId, projection.Id))
                throw new Exception("Postoji vremensko i lokacijsko preklapanje sa postojećim projekcijama. \n\nObratite pažnju na odabrane lokacije i dvorane projekcije. \n\nNapomena: Obavezni razmak između projekcija je 15 minuta!");

            projection.StartsAt = startsAt;
            projection.EndsAt = endsAt;
            projection.HallId = hallId;

            await _context.SaveChangesAsync();

            return projection;
        }

        public async Task CancelAsync(int id)
        {
            var projection = _context.Projections.SingleOrDefault(p => p.Id == id);

            if (projection == null) throw new Exception($"Projekcija sa id: {id} ne postoji");

            projection.IsCanceled = true;

            await _context.SaveChangesAsync();

            return;
        }

        private async Task<bool> CheckProjectionOverlaping(DateTime projectionStart, DateTime projectionEnd, int locationId, int hallId, int? projectionId = null)
        {
            //15 min projection break
            projectionStart = projectionStart.AddMinutes(-15);
            projectionEnd = projectionEnd.AddMinutes(15);

            var projections = await _context.Projections
                .Where(p => p.Id != projectionId &&
                            projectionStart.Date == p.StartsAt.Date &&
                            p.IsCanceled == false &&
                            p.LocationId == locationId &&
                            p.HallId == hallId)
                .ToListAsync();

            foreach (var projection in projections)
            {
                //time and location overlap => false
                if (projectionStart > projection.StartsAt && projectionStart < projection.EndsAt ||
                    projectionEnd > projection.StartsAt && projectionEnd < projection.EndsAt)
                {
                    return false;
                }
            }
            return true;
        }
    }
}