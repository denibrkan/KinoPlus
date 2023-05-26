using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [RequestSizeLimit(24 * 1024 * 1024)]
        [HttpPost]
        public async Task<ActionResult<List<Guid>>> Upload(IFormFile[] images)
        {
            if (images.Length == 0) return BadRequest("Slike nisu poslane");
            if (images.Length > 10)
            {
                return BadRequest("You cannot upload more than 10 images");
            }

            var imageIds = await _imageService.ProcessAsync(images.Select(i => new ImageInputModel
            {
                FileName = i.FileName,
                Type = i.ContentType,
                Content = i.OpenReadStream()
            }));

            return Ok(imageIds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetImage(Guid id, bool original = false)
        {
            var imageBytes = await _imageService.GetImageAsync(id, original);
            if (imageBytes == null) return BadRequest();

            return File(imageBytes, "image/jpeg");
        }

    }
}
