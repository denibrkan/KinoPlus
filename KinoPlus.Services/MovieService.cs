using KinoPlus.Models.SearchObjects;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class MovieService : BaseService<Movie, BaseSearchObject>, IMovieService
    {

        public MovieService(KinoplusContext context) : base(context) { }

        public override IQueryable<Movie> AddInclude(IQueryable<Movie> query, BaseSearchObject search)
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
    }
}
