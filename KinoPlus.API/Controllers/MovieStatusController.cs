using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class MovieStatusController : BaseController<MovieStatus, MovieStatusDto, BaseSearchObject>
    {
        public MovieStatusController(IMovieStatusService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
