using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;
        private readonly IMapper _mapper;

        public RecommendationController(IRecommendationService recommendationService, IMapper mapper)
        {
            _recommendationService = recommendationService;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<MovieDto>>> Recommend(int userId)
        {
            var movies = await _recommendationService.Recommend(userId);

            return Ok(_mapper.Map<List<MovieDto>>(movies));
        }
    }
}
