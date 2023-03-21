using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
