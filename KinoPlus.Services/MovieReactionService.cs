using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class MovieReactionService : BaseCRUDService<MovieReaction, MovieReactionUpsertObject, MovieReactionUpsertObject, BaseSearchObject>, IMovieReactionService
    {
        public MovieReactionService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override Task BeforeInsert(MovieReactionUpsertObject insert, MovieReaction entity)
        {
            entity.DateCreated = DateTime.Now;

            return Task.CompletedTask;
        }
    }
}
