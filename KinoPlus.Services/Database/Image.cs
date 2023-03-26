namespace KinoPlus.Services.Database;

public partial class Image
{
    public Image()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public byte[] OriginalContent { get; set; } = null!;

    public byte[] ThumbnailContent { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
