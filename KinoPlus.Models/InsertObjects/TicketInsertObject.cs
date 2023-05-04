using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class TicketInsertObject
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? ProjectionId { get; set; }
        [Required]
        public int? SeatId { get; set; }
    }
}
