using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class ActorService : BaseCRUDService<Actor, ActorUpsertObject, ActorUpsertObject, BaseSearchObject>, IActorService
    {
        public ActorService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
