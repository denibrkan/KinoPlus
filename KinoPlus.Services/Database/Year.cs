namespace KinoPlus.Services.Database;

public partial class Year
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
