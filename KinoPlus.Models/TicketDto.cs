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
    }
}