namespace KinoPlus.Services.Database;

public partial class Hall
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<HallSeat> HallSeats { get; } = new List<HallSeat>();

    public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();
}
