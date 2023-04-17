using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ProjectionInsertObject
    {
        [Required]
        public DateTime? StartsAt { get; set; }
        public DateTime? ProjectionDate { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? ProjectionTypeId { get; set; }
        [Required]
        public int? MovieId { get; set; }
        [Required]
        public List<LocationHallInsertObject> Locations { get; set; }
        //  public int? RecurringProjectionId { get; set; }
        //  public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();
    }
}
