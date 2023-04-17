using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class LocationHallInsertObject
    {
        [Required]
        public int? LocationId { get; set; }
        [Required]
        public int? HallId { get; set; }
    }
}
