using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface ILocationService : ICRUDService<Location, LocationUpsertObject, LocationUpsertObject, LocationSearchObject>
    {
    }
}
