using KinoPlus.Models;

namespace KinoPlus.Services.Interfaces
{
    public interface ICRUDService<T, TInsert, TUpdate, TSearch> : IService<T, TSearch>
            where T : class where TInsert : class where TUpdate : class where TSearch : BaseSearchObject
    {
        Task<T> InsertAsync(TInsert insert);
        Task<bool> UpdateAsync(int id, TUpdate update);
    }
}
