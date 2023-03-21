using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class BaseCRUDService<T, TInsert, TUpdate, TSearch> : BaseService<T, TSearch>, ICRUDService<T, TInsert, TUpdate, TSearch>
          where T : class where TInsert : class where TUpdate : class where TSearch : BaseSearchObject
    {
        private readonly IMapper _mapper;
        private readonly KinoplusContext _context;

        public BaseCRUDService(KinoplusContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public virtual async Task<T> InsertAsync(TInsert insert)
        {
            var entity = _mapper.Map<T>(insert);

            _context.Set<T>().Add(entity);

            BeforeInsert(insert, entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(int id, TUpdate update)
        {
            var entity = _context.Set<T>().Find(id);

            _mapper.Map(update, entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public virtual void BeforeInsert(TInsert insert, T entity)
        {
            return;
        }
    }
}
