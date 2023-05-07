using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ProjectionInsertObject
    {
        [Required]
        public DateTime? ProjectionTime { get; set; }
        public DateTime? ProjectionDate { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int? DayOfWeekId { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? ProjectionTypeId { get; set; }
        [Required]
        public int? MovieId { get; set; }
        [Required]
        public List<LocationHallInsertObject> Locations { get; set; }
        public bool IsRecurring { get; set; }
    }
}
