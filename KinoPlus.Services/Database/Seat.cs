namespace KinoPlus.Services.Database;

public partial class Seat
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Row { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
