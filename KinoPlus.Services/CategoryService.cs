using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class CategoryService : BaseCRUDService<Category, CategoryUpsertObject, CategoryUpsertObject, CategorySearchObject>, ICategoryService
    {
        private readonly KinoplusContext _context;

        public CategoryService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<Category> UpdateAsync(int id, CategoryUpsertObject upsert)
        {
            var updated = await base.UpdateAsync(id, upsert);

            await OnUpsert(id, upsert);

            return updated;
        }

        public override async Task<Category> InsertAsync(CategoryUpsertObject upsert)
        {
            var inserted = await base.InsertAsync(upsert);

            await OnUpsert(inserted.Id, upsert);

            return inserted;
        }

        private async Task OnUpsert(int id, CategoryUpsertObject upsert)
        {
            var category = _context.Categories.Include(c => c.MovieCategories).SingleOrDefault(c => c.Id == id);
            _context.MovieCategories.RemoveRange(category!.MovieCategories);

            var movieCategories = new List<MovieCategory>();

            foreach (var item in upsert.MovieIds)
            {
                movieCategories.Add(new MovieCategory
                {
                    MovieId = item,
                    CategoryId = id
                });
            }

            _context.AddRange(movieCategories);
            await _context.SaveChangesAsync();
        }

        public override IQueryable<Category> AddFilter(IQueryable<Category> query, CategorySearchObject search)
        {
            if (search.IsDisplayed.HasValue && search.IsDisplayed.Value == true)
            {
                query = query.Where(c => c.IsDisplayed);
            }
            if (!string.IsNullOrEmpty(search.NameFTS))
            {
                query = query.Where(c => c.Name.Contains(search.NameFTS));
            }

            return query;
        }

        public override IQueryable<Category> AddSorting(IQueryable<Category> query, CategorySearchObject search)
        {
            query = query.OrderByDescending(c => c.OrderPoints);

            return query;
        }

        public override IQueryable<Category> AddInclude(IQueryable<Category> query, CategorySearchObject? search)
        {
            query = base.AddInclude(query, search);

            if (search?.IncludeMovies == true)
            {
                query = query
                    .AsSplitQuery()
                    .Include(c => c.MovieCategories.OrderByDescending(mc => mc.Movie.DateCreated))
                        .ThenInclude(c => c.Movie)
                        .ThenInclude(m => m.MovieGenres)
                        .ThenInclude(mg => mg.Genre)
                    .Include(c => c.MovieCategories)
                        .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieActors)
                        .ThenInclude(ma => ma.Actor)
                    .Include(c => c.MovieCategories)
                        .ThenInclude(m => m.Movie)
                        .ThenInclude(m => m.MovieReactions)
                    .AsNoTracking();
            }

            return query;
        }
    }
}
