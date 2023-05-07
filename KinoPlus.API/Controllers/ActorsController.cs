using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class ActorsController : BaseCRUDController<Actor, ActorDto, ActorUpsertObject, ActorUpsertObject, BaseSearchObject>
    {
        public ActorsController(IActorService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
