using System;

namespace KinoPlus.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int SeatId { get; set; }
        public int UserId { get; set; }
        public int ProjectionId { get; set; }
        public SeatDto Seat { get; set; }
        public string MovieTitle { get; set; }
        public Guid? MovieImageId { get; set; }
        public DateTime ProjectionStart { get; set; }
        public DateTime ProjectionEnd { get; set; }
        public HallDto Hall { get; set; }
        public LocationDto Location { get; set; }
    }
}