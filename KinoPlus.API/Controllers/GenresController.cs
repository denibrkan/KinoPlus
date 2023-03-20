using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class GenresController : BaseCRUDController<Genre, GenreDto, GenreUpsertObject, GenreUpsertObject, BaseSearchObject>
    {

        public GenresController(IGenreService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
