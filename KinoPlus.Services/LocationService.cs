using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.Services
{
    public class LocationService : BaseCRUDService<Location, LocationInsertObject, LocationInsertObject, BaseSearchObject>, ILocationService
    {
        public LocationService(KinoplusContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
