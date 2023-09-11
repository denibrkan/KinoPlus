namespace KinoPlus.Services.Database;

public partial class Fitpasos
{
    public int Id { get; set; }

    public DateTime DateIssued { get; set; }

    public DateTime ValidUntil { get; set; }

    public bool IsValid { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
