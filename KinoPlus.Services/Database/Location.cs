using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class Location
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<LocationHall> LocationHalls { get; } = new List<LocationHall>();

    public virtual ICollection<LocationProjectionType> LocationProjectionTypes { get; } = new List<LocationProjectionType>();

    public virtual ICollection<ProjectionLocation> ProjectionLocations { get; } = new List<ProjectionLocation>();
}
