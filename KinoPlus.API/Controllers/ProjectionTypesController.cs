using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;

namespace KinoPlus.API.Controllers
{
    public class ProjectionTypesController : BaseController<ProjectionType, ProjectionTypeDto, BaseSearchObject>
    {
        public ProjectionTypesController(IProjectionTypeService service, IMapper mapper) : base(service, mapper)
        {
        }

    }
}
