using System;
using System.Collections.Generic;

namespace KinoPlus.Services.Database;

public partial class Projection
{
    public int Id { get; set; }

    public DateTime StartsAt { get; set; }

    public DateTime EndsAt { get; set; }

    public decimal Price { get; set; }

    public int ProjectionTypeId { get; set; }

    public int MovieId { get; set; }

    public int? RecurringProjectionId { get; set; }

    public int LocationId { get; set; }

    public int HallId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual ProjectionType ProjectionType { get; set; } = null!;

    public virtual RecurringProjection? RecurringProjection { get; set; }

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();
}
