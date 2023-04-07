using System;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ProjectionSearchObject : BaseSearchObject
    {
        [Required]
        public DateTime? Date { get; set; }
        public int? LocationId { get; set; }
    }
}
