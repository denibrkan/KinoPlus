namespace KinoPlus.Services.Database;

public partial class Year
{
    public int Id { get; set; }

    public int Name { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
