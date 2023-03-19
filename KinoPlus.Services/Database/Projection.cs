namespace KinoPlus.Services.Database;

public partial class Projection
{
    public int Id { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime EndsAt { get; set; }

    public decimal Price { get; set; }

    public int ProjectionTypeId { get; set; }

    public int MovieId { get; set; }

    public int? RecurringProjectionId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();

    public virtual ProjectionType ProjectionType { get; set; } = null!;

    public virtual RecurringProjection? RecurringProjection { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
