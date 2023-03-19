namespace KinoPlus.Services.Database;

public partial class DayOfWeek
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<RecurringProjection> RecurringProjections { get; } = new List<RecurringProjection>();
}
