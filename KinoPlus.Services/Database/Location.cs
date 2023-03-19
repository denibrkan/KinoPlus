namespace KinoPlus.Services.Database;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();
}
