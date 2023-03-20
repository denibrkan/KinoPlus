using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Models.SearchObjects;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class MoviesController : BaseController<Movie, MovieDto, BaseSearchObject>
    {

        public MoviesController(IMovieService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
