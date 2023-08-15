using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Database;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class ProjectionsController : BaseController<Projection, ProjectionDto, ProjectionSearchObject>
    {
        private readonly IProjectionService _service;
        private readonly IMapper _mapper;

        public ProjectionsController(IProjectionService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectionDto>>> Post(ProjectionInsertObject insert)
        {
            if (insert == null) return BadRequest();

            var created = await _service.InsertProjectionsAsync(insert);

            return Ok(_mapper.Map<List<ProjectionDto>>(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectionDto>> Put(int id, ProjectionUpdateObject projectionUpdate)
        {
            var projection = await _service.UpdateAsync(id, projectionUpdate);

            return _mapper.Map<ProjectionDto>(projection);
        }
    }
}
