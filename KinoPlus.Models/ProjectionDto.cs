using System;
using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class ProjectionDto
    {
        public int Id { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public decimal Price { get; set; }
        public int TicketCount { get; set; }
        public int MovieId { get; set; }
        public int LocationId { get; set; }
        public int HallId { get; set; }
        public MovieDto Movie { get; set; }
        public int ProjectionTypeId { get; set; }
        public ProjectionTypeDto ProjectionType { get; set; }
        public LocationDto Location { get; set; }
        public HallDto Hall { get; set; }
        public List<TicketDto> Tickets { get; set; }
        public int? RecurringProjectionId { get; set; }
    }
}