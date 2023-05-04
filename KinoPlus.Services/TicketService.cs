using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class TicketService : BaseService<Ticket, TicketSearchObject>, ITicketService
    {
        private readonly KinoplusContext _context;

        public TicketService(KinoplusContext context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Ticket> AddInclude(IQueryable<Ticket> query, TicketSearchObject? search)
        {
            query = query
                .Include(t => t.Projection.Location.City)
                .Include(t => t.Projection.Hall)
                .Include(t => t.Projection.Movie)
                .Include(t => t.Seat);

            return query;
        }

        public override IQueryable<Ticket> AddSorting(IQueryable<Ticket> query, TicketSearchObject search)
        {
            query = query.OrderByDescending(t => t.DateOfPurchase);

            return query;
        }

        public override IQueryable<Ticket> AddFilter(IQueryable<Ticket> query, TicketSearchObject search)
        {
            query = base.AddFilter(query, search);

            if (search.UserId != null)
            {
                query = query.Where(t => t.UserId == search.UserId);
            }

            return query;
        }

        public async Task<List<Ticket>> InsertTicketsAsync(IEnumerable<TicketInsertObject> tickets)
        {
            var entities = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                entities.Add(new Ticket
                {
                    DateOfPurchase = DateTime.Now,
                    ProjectionId = ticket.ProjectionId!.Value,
                    SeatId = ticket.SeatId!.Value,
                    UserId = ticket.UserId!.Value,
                });
            }
            _context.AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }
    }
}
