using KinoPlus.Models.SearchObjects;

namespace KinoPlus.Services.Interfaces
{
    public interface IService<T, TSearch> where T : class where TSearch : BaseSearchObject
    {
        public Task<IEnumerable<T>> GetAsync(TSearch search);
        public Task<T> GetByIdAsync(int id);
    }
}
