using System;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ProjectionUpdateObject
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public DateTime? StartsAt { get; set; }
        [Required]
        public int? HallId { get; set; }
    }
}
