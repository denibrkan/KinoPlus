using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class TicketsController : BaseController<Ticket, TicketDto, TicketSearchObject>
    {
        private readonly ITicketService _service;
        private readonly IMapper _mapper;

        public TicketsController(ITicketService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<List<TicketDto>> PostAsync(TicketInsertObject[] tickets)
        {
            var inserted = await _service.InsertTicketsAsync(tickets);

            return _mapper.Map<List<TicketDto>>(inserted);
        }
    }
}
