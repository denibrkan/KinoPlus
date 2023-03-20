using KinoPlus.Models.SearchObjects;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IMovieService : IService<Movie, BaseSearchObject>
    {
    }
}
