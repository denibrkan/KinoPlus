using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class MovieReactionsController : BaseCRUDController<MovieReaction, MovieReactionDto, MovieReactionUpsertObject, MovieReactionUpsertObject, BaseSearchObject>
    {
        public MovieReactionsController(IMovieReactionService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
