using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IProjectionService : ICRUDService<Projection, ProjectionInsertObject, ProjectionInsertObject, ProjectionSearchObject>
    {
    }
}
