using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class MovieService : BaseCRUDService<Movie, MovieUpsertObject, MovieUpsertObject, MovieSearchObject>, IMovieService
    {
        private readonly KinoplusContext _context;

        public MovieService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public override async Task<Movie?> GetByIdAsync(int id)
        {
            var query = _context.Movies.AsQueryable();

            query = AddInclude(query, null);

            return await query.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async override Task<Movie> InsertAsync(MovieUpsertObject insert)
        {
            var movie = await base.InsertAsync(insert);
            //insert related data
            InsertRelatedEntities(insert, movie.Id);

            await _context.SaveChangesAsync();

            return (await GetByIdAsync(movie.Id))!;
        }

        public override void BeforeInsert(MovieUpsertObject insert, Movie entity)
        {
            base.BeforeInsert(insert, entity);

            entity.DateCreated = DateTime.UtcNow;
        }

        public async override Task<Movie> UpdateAsync(int id, MovieUpsertObject update)
        {
            await base.UpdateAsync(id, update);
            var movie = await GetByIdAsync(id);

            if (!movie!.MovieCategories.Select(x => x.CategoryId).SequenceEqual(update.CategoryIds))
            {
                _context.RemoveRange(movie.MovieCategories);

                InsertRelatedCategories(update, movie.Id);
            }
            if (!movie.MovieActors.Select(x => x.ActorId).SequenceEqual(update.ActorIds))
            {
                _context.RemoveRange(movie.MovieActors);

                InsertRelatedActors(update, movie.Id);
            }
            if (!movie.MovieGenres.Select(mc => mc.GenreId).SequenceEqual(update.GenreIds))
            {
                _context.RemoveRange(movie.MovieGenres);

                InsertRelatedGenres(update, movie.Id);
            }

            await _context.SaveChangesAsync();

            return (await GetByIdAsync(movie.Id))!;
        }

        public override IQueryable<Movie> AddInclude(IQueryable<Movie> query, MovieSearchObject? search)
        {
            query = query
                .Include(x => x.MovieCategories).ThenInclude(x => x.Category)
                .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MovieActors).ThenInclude(x => x.Actor)
                .Include(x => x.Projections)
                .Include(x => x.MovieReactions).ThenInclude(mr => mr.User)
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

        public override IQueryable<Movie> AddSorting(IQueryable<Movie> query, MovieSearchObject search)
        {
            query = query.OrderByDescending(x => x.DateCreated);

            return query;
        }

        public void InsertRelatedEntities(MovieUpsertObject movie, int movieId)
        {
            foreach (var item in movie.GenreIds)
            {
                var movieGenre = new MovieGenre
                {
                    MovieId = movieId,
                    GenreId = item
                };
                _context.MovieGenres.Add(movieGenre);
            }
            foreach (var item in movie.CategoryIds)
            {
                var movieCategory = new MovieCategory
                {
                    MovieId = movieId,
                    CategoryId = item
                };
                _context.MovieCategories.Add(movieCategory);
            }
            foreach (var item in movie.ActorIds)
            {
                var actors = new MovieActor
                {
                    MovieId = movieId,
                    ActorId = item
                };
                _context.MovieActors.Add(actors);
            }
        }

        public void InsertRelatedCategories(MovieUpsertObject movie, int movieId)
        {
            foreach (var item in movie.CategoryIds)
            {
                var movieCategory = new MovieCategory
                {
                    MovieId = movieId,
                    CategoryId = item
                };
                _context.MovieCategories.Add(movieCategory);
            }
        }

        public void InsertRelatedGenres(MovieUpsertObject movie, int movieId)
        {
            foreach (var item in movie.GenreIds)
            {
                var movieGenre = new MovieGenre
                {
                    MovieId = movieId,
                    GenreId = item
                };
                _context.MovieGenres.Add(movieGenre);
            }
        }

        public void InsertRelatedActors(MovieUpsertObject movie, int movieId)
        {
            foreach (var item in movie.ActorIds)
            {
                var actors = new MovieActor
                {
                    MovieId = movieId,
                    ActorId = item
                };
                _context.MovieActors.Add(actors);
            }
        }
    }
}
