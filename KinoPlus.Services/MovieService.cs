using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Models.Enumerations.Sorters;
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

        public async Task<List<Movie>> GetMostPopularAsync()
        {
            var activeStatus = _context.MovieStatuses.Single(s => s.Name == "Active");
            var query = _context.Movies.AsQueryable();

            query = AddInclude(query, null);

            return await query
                 .Where(m => m.MovieStatusId == activeStatus.Id)
                 .OrderByDescending(m => m.Popularity)
                 .Take(5)
                 .ToListAsync();
        }

        public List<Movie> GetByIds(List<int> ids)
        {
            var query = _context.Movies.AsQueryable();

            query = AddInclude(query, null);

            return query
                 .Where(m => ids.Contains(m.Id))
                 .AsEnumerable()
                 .OrderBy(x => ids.IndexOf(x.Id))
                 .ToList();
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

        public override async Task BeforeInsert(MovieUpsertObject insert, Movie entity)
        {
            await base.BeforeInsert(insert, entity);

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
                .AsSplitQuery()
                .Include(x => x.MovieCategories).ThenInclude(x => x.Category)
                .Include(x => x.MovieGenres).ThenInclude(x => x.Genre)
                .Include(x => x.MovieActors).ThenInclude(x => x.Actor)
                .Include(x => x.MovieReactions).ThenInclude(mr => mr.User)
                .Include(x => x.Year)
                .Include(x => x.MovieStatus);

            return query;
        }

        public override IQueryable<Movie> AddFilter(IQueryable<Movie> query, MovieSearchObject search)
        {
            base.AddFilter(query, search);

            if (search.ActiveOnly == true)
            {
                var activeStatus = _context.MovieStatuses.Single(s => s.Name == "Active");

                query = query.Where(x => x.MovieStatusId == activeStatus.Id);
            }
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
            if (search.GenreId.HasValue)
            {
                query = query.Where(x => x.MovieGenres.Any(y => y.GenreId == search.GenreId.Value));
            }
            return query;
        }

        public override IQueryable<Movie> AddSorting(IQueryable<Movie> query, MovieSearchObject search)
        {
            if (!string.IsNullOrEmpty(search.SortBy))
            {
                switch (search.SortBy)
                {
                    case MovieSorting.DateCreated:
                        query = query.OrderByDescending(x => x.DateCreated);
                        break;
                    case MovieSorting.Popularity:
                        query = query.OrderByDescending(x => x.Popularity);
                        break;
                    case MovieSorting.Rating:
                        query = query.OrderByDescending(x => x.MovieReactions.Average(mr => mr.Rating));
                        break;
                    case MovieSorting.Title:
                        query = query.OrderBy(x => x.Title);
                        break;
                }
            }
            else
            {
                query = query.OrderByDescending(x => x.DateCreated);
            }

            return query;
        }

        public void InsertRelatedEntities(MovieUpsertObject movie, int movieId)
        {
            InsertRelatedCategories(movie, movieId);
            InsertRelatedGenres(movie, movieId);
            InsertRelatedActors(movie, movieId);
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
