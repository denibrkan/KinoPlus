namespace KinoPlus.Services.Database;

public partial class MovieCategory
{
    public int Id { get; set; }

    public int MovieId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
