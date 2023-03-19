namespace KinoPlus.Services.Database;

public partial class HallSeat
{
    public int Id { get; set; }

    public int HallId { get; set; }

    public int SeatId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Seat Seat { get; set; } = null!;
}
