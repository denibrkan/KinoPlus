using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class RecurringProjection
{
    public int Id { get; set; }

    public int WeekDayId { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime EndingDate { get; set; }

    public TimeSpan ProjectionTime { get; set; }

    public virtual ICollection<Projection> Projections { get; } = new List<Projection>();

    public virtual WeekDay WeekDay { get; set; } = null!;
}
