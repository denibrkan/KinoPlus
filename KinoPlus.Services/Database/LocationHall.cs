using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class LocationHall
{
    public int Id { get; set; }

    public int LocationId { get; set; }

    public int HallId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
