using System;

namespace KinoPlus.Models
{
    public class ProjectionDto
    {
        public int Id { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public decimal Price { get; set; }
        public int MovieId { get; set; }
    }
}