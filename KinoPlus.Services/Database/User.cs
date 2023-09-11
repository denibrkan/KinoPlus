namespace KinoPlus.Services.Database;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public Guid? ImageId { get; set; }

    public int? LocationId { get; set; }

    public virtual Image? Image { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<MovieReaction> MovieReactions { get; } = new List<MovieReaction>();

    public virtual ICollection<Ticket> Tickets { get; } = new List<Ticket>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
    public virtual ICollection<Fitpasos> Fitpasosi { get; } = new List<Fitpasos>();
}
