using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class MoviesController : BaseCRUDController<Movie, MovieDto, MovieUpsertObject, MovieUpsertObject, MovieSearchObject>
    {

        public MoviesController(IMovieService service, IMapper mapper) : base(service, mapper)
        {
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<MovieDto>>> Get([FromQuery] MovieSearchObject search)
        {
            return base.Get(search);
        }

    }
}
