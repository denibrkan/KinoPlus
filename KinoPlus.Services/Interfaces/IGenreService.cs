using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IGenreService : ICRUDService<Genre, GenreUpsertObject, GenreUpsertObject, BaseSearchObject>
    {

    }
}
