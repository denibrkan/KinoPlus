using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IMovieService : IService<Movie, MovieSearchObject>
    {
    }
}
