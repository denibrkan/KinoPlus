using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class MoviesController : BaseController<Movie, MovieDto, MovieSearchObject>
    {

        public MoviesController(IMovieService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
