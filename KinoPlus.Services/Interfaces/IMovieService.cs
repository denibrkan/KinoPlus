using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
    }
}
