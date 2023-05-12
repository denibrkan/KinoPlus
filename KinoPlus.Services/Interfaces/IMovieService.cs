using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IMovieService : ICRUDService<Movie, MovieUpsertObject, MovieUpsertObject, MovieSearchObject>
    {
        Task<List<Movie>> GetMostPopularAsync();
        List<Movie> GetByIds(List<int> ids);
    }
}
