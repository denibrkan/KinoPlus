namespace KinoPlus.Services.Database;

public partial class Ticket
{
    public int Id { get; set; }

    public DateTime DateOfPurchase { get; set; }

    public int SeatId { get; set; }

    public int UserId { get; set; }

    public int ProjectionId { get; set; }

    public virtual Projection Projection { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
