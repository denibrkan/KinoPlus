using KinoPlus.Models;
using KinoPlus.Services.Database;

namespace KinoPlus.Services.Interfaces
{
    public interface IProjectionService : IService<Projection, ProjectionSearchObject>
    {
        Task<List<Projection>> InsertProjectionsAsync(ProjectionInsertObject insertObject);
        Task<Projection> UpdateAsync(int id, ProjectionUpdateObject updateObject);
        Task CancelAsync(int id);
    }
}