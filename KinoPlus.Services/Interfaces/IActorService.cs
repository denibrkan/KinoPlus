using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IActorService : ICRUDService<Actor, ActorUpsertObject, ActorUpsertObject, BaseSearchObject>
    {

    }
}
