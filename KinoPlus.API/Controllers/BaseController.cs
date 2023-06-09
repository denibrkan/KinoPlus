﻿using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TDto, TSearch> : ControllerBase where T : class where TDto : class where TSearch : BaseSearchObject
    {
        private readonly IService<T, TSearch> _service;
        private readonly IMapper _mapper;

        public BaseController(IService<T, TSearch> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TDto>>> Get([FromQuery] TSearch search)
        {
            var list = await _service.GetAsync(search);

            return Ok(_mapper.Map<List<TDto>>(list));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);

            return Ok(_mapper.Map<TDto>(item));
        }
    }
}
