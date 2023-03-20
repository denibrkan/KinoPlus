using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class LocationProjectionType
{
    public int Id { get; set; }

    public int LocationId { get; set; }

    public int ProjectionTypeId { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual ProjectionType ProjectionType { get; set; } = null!;
}
