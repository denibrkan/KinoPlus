namespace KinoPlus.Services.Database;

public partial class Actor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MovieActor> MovieActors { get; } = new List<MovieActor>();
}
