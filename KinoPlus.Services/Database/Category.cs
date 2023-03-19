namespace KinoPlus.Services.Database;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MovieCategory> MovieCategories { get; } = new List<MovieCategory>();
}
