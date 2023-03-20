using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    public class BaseCRUDController<T, TDto, TInsert, TUpdate, TSearch> : BaseController<T, TDto, TSearch>
             where T : class where TDto : class where TInsert : class where TUpdate : class where TSearch : BaseSearchObject
    {
        private readonly ICRUDService<T, TInsert, TUpdate, TSearch> _service;
        private readonly IMapper _mapper;

        public BaseCRUDController(ICRUDService<T, TInsert, TUpdate, TSearch> service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TDto>> Post(TInsert insert)
        {
            if (insert == null) return BadRequest();

            var created = await _service.InsertAsync(insert);

            return Ok(_mapper.Map<TDto>(created));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> Put(int id, TUpdate insert)
        {
            if (insert == null) return BadRequest();

            var updated = await _service.UpdateAsync(id, insert);

            return Ok(_mapper.Map<TDto>(updated));
        }
    }
}
