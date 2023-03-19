namespace KinoPlus.Services.Database;

public partial class MovieReaction
{
    public int Id { get; set; }

    public byte Rating { get; set; }

    public string? Comment { get; set; }

    public int MovieId { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
