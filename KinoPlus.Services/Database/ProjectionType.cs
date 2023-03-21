namespace KinoPlus.Services.Database;

public partial class ProjectionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Projection> Projections { get; } = new List<Projection>();

    public virtual ICollection<LocationProjectionType> LocationProjectionTypes { get; } = new List<LocationProjectionType>();
}
