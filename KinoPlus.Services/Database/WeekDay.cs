using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class WeekDay
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RecurringProjection> RecurringProjections { get; } = new List<RecurringProjection>();
}
