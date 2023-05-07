using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class ProjectionsController : BaseCRUDController<Projection, ProjectionDto, ProjectionInsertObject, ProjectionInsertObject, ProjectionSearchObject>
    {
        public ProjectionsController(IProjectionService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
