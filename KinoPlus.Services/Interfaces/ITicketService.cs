using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface ITicketService : IService<Ticket, BaseSearchObject>
    {
        Task<List<Ticket>> InsertTicketsAsync(IEnumerable<TicketInsertObject> tickets);
    }
}
