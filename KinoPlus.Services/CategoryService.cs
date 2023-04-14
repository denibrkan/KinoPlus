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
                    .AsSplitQuery()
                    .Include(c => c.MovieCategories)
                    .ThenInclude(c => c.Movie)
                        .ThenInclude(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieReactions).ThenInclude(mr => mr.User)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieActors).ThenInclude(ma => ma.Actor)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.Projections)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.Year)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieStatus)
                    .Include(c => c.MovieCategories)
                    .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieStatus)
                    .AsNoTracking();
            }

            return query;
        }
    }
}
