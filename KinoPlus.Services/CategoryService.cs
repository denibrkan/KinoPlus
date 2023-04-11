using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class CategoryService : BaseCRUDService<Category, CategoryInsertObject, CategoryUpdateObject, CategorySearchObject>, ICategoryService
    {
        public CategoryService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Category> AddInclude(IQueryable<Category> query, CategorySearchObject? search)
        {
            query = base.AddInclude(query, search);

            if (search?.IncludeMovies == true)
            {
                query = query
                    .Include(c => c.MovieCategories)
                    .ThenInclude(c => c.Movie);
            }

            return query;
        }
    }
}
