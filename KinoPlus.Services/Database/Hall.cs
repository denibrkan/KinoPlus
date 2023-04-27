using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class Hall
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<LocationHall> LocationHalls { get; } = new List<LocationHall>();

    public virtual ICollection<Projection> Projections { get; } = new List<Projection>();
}
