using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class TicketService : BaseService<Ticket, BaseSearchObject>, ITicketService
    {
        private readonly KinoplusContext _context;

        public TicketService(KinoplusContext context) : base(context)
        {
            _context = context;
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
