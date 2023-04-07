using System;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ProjectionInsertObject
    {
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public decimal Price { get; set; }
        [Required]
        public int? ProjectionTypeId { get; set; }
        [Required]
        public int? MovieId { get; set; }
        //  public int? RecurringProjectionId { get; set; }
        //  public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();
    }
}
