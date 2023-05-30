using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KinoPlus.Services
{
    public class MovieReactionService : BaseCRUDService<MovieReaction, MovieReactionUpsertObject, MovieReactionUpsertObject, MovieReactionSearchObject>, IMovieReactionService
    {
        private readonly IRecommendationService _recommendationService;

        public MovieReactionService(KinoplusContext context, IMapper mapper, IRecommendationService recommendationService) : base(context, mapper)
        {
            _recommendationService = recommendationService;
        }

        public async override Task<MovieReaction> InsertAsync(MovieReactionUpsertObject insert)
        {
            var inserted = await base.InsertAsync(insert);

            await _recommendationService.CreateModel();

            return inserted;
        }

        public override IQueryable<MovieReaction> AddSorting(IQueryable<MovieReaction> query, MovieReactionSearchObject search)
        {
            query = query.OrderByDescending(x => x.DateCreated);

            return query;
        }

        public override IQueryable<MovieReaction> AddFilter(IQueryable<MovieReaction> query, MovieReactionSearchObject search)
        {
            if (search.MovieId != null)
            {
                query = query.Where(r => r.MovieId == search.MovieId);
            }

            return query;
        }

        public override IQueryable<MovieReaction> AddInclude(IQueryable<MovieReaction> query, MovieReactionSearchObject? search)
        {
            query = query.Include(r => r.User);

            return query;
        }

        public override Task BeforeInsert(MovieReactionUpsertObject insert, MovieReaction entity)
        {
            entity.DateCreated = DateTime.Now;

            return Task.CompletedTask;
        }
    }
}
