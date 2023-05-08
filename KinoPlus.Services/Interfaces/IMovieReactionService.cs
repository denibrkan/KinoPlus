using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IMovieReactionService : ICRUDService<MovieReaction, MovieReactionUpsertObject, MovieReactionUpsertObject, BaseSearchObject>
    {

    }
}
