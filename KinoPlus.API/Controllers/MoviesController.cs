using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class MoviesController : BaseCRUDController<Movie, MovieDto, MovieUpsertObject, MovieUpsertObject, MovieSearchObject>
    {

        public MoviesController(IMovieService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
