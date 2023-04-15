using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class ProjectionsController : BaseCRUDController<Projection, ProjectionDto, ProjectionInsertObject, ProjectionInsertObject, ProjectionSearchObject>
    {

        public ProjectionsController(IProjectionService service, IMapper mapper) : base(service, mapper)
        {
        }

        [AllowAnonymous]
        public override Task<ActionResult<List<ProjectionDto>>> Get([FromQuery] ProjectionSearchObject search)
        {
            return base.Get(search);
        }

    }
}
