using KinoPlus.Models.SearchObjects;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class BaseService<T, TSearch> : IService<T, TSearch> where T : class where TSearch : BaseSearchObject
    {
        private readonly KinoplusContext _context;

        public BaseService(KinoplusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAsync(TSearch search)
        {
            var entities = _context.Set<T>().AsQueryable();

            entities = AddInclude(entities, search);

            if (search.Page.HasValue == true && search.PageSize.HasValue == true)
            {
                entities = entities.Skip((search.Page.Value - 1) * search.PageSize.Value).Take(search.PageSize.Value);
            }

            return await entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> AddInclude(IQueryable<T> query, TSearch search)
        {
            return query;
        }
    }
}
