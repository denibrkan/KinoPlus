namespace KinoPlus.Services.Database;

public partial class ProjectionLocation
{
    public int Id { get; set; }

    public int ProjectionId { get; set; }

    public int LocationId { get; set; }

    public int HallId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Projection Projection { get; set; } = null!;
}
