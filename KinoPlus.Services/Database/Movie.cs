namespace KinoPlus.Services.Database;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Duration { get; set; }

    public string? Description { get; set; }

    public string? TrailerUrl { get; set; }

    public double Popularity { get; set; }

    public Guid? ImageId { get; set; }

    public int YearId { get; set; }

    public int MovieStatusId { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Image? Image { get; set; }

    public virtual ICollection<MovieActor> MovieActors { get; } = new List<MovieActor>();

    public virtual ICollection<MovieCategory> MovieCategories { get; } = new List<MovieCategory>();

    public virtual ICollection<MovieGenre> MovieGenres { get; } = new List<MovieGenre>();

    public virtual ICollection<MovieReaction> MovieReactions { get; } = new List<MovieReaction>();

    public virtual MovieStatus MovieStatus { get; set; } = null!;

    public virtual ICollection<Projection> Projections { get; } = new List<Projection>();

    public virtual Year Year { get; set; } = null!;
}
