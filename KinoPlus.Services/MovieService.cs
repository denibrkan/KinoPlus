using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class MovieService : BaseService<Movie, MovieSearchObject>, IMovieService
    {

        public MovieService(KinoplusContext context) : base(context) { }

        public override IQueryable<Movie> AddInclude(IQueryable<Movie> query, MovieSearchObject search)
        {
            query = query
                .Include(x => x.MovieCategories).ThenInclude(x => x.Category)
                .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MovieActors).ThenInclude(x => x.Actor)
                .Include(x => x.Projections)
                .Include(x => x.MovieReactions)
                .Include(x => x.Year)
                .Include(x => x.MovieStatus);

            return query;
        }

        public override IQueryable<Movie> AddFilter(IQueryable<Movie> query, MovieSearchObject search)
        {
            base.AddFilter(query, search);

            if (!string.IsNullOrEmpty(search.TitleFTS))
            {
                query = query.Where(x => x.Title.Contains(search.TitleFTS));
            }
            if (search.StatusId.HasValue)
            {
                query = query.Where(x => x.MovieStatusId == search.StatusId.Value);
            }
            if (search.CategoryId.HasValue)
            {
                query = query.Where(x => x.MovieCategories.Any(y => y.CategoryId == search.CategoryId.Value));
            }

            return query;
        }
    }
}
