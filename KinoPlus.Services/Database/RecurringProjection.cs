namespace KinoPlus.Services.Database;

public partial class RecurringProjection
{
    public int Id { get; set; }

    public int DayOfWeekId { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime EndsAt { get; set; }

    public TimeSpan ProjectionTime { get; set; }

    public virtual DayOfWeek DayOfWeek { get; set; } = null!;

    public virtual ICollection<Projection> Projections { get; } = new List<Projection>();
}
