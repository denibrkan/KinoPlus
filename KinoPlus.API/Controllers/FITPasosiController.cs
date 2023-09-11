using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Models.UpsertObjects;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class FITPasosiController : BaseCRUDController<Fitpasos, FITPasosDto, FITPasosUpsertObject, FITPasosUpsertObject, FITPasosSearchObject>
    {
        public FITPasosiController(IFITPasosService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
