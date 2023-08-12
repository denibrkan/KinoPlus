using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IProjectionService : IService<Projection, ProjectionSearchObject>
    {
        Task<List<Projection>> InsertProjectionsAsync(ProjectionInsertObject insertObject);
    }
}
