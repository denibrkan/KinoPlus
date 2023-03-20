using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class GenreService : BaseCRUDService<Genre, GenreUpsertObject, GenreUpsertObject, BaseSearchObject>, IGenreService
    {
        public GenreService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
