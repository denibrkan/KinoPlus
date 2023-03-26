using KinoPlus.Models;

namespace KinoPlus.Services.Interfaces
{
    public interface IImageService
    {
        Task<List<Guid>> ProcessAsync(IEnumerable<ImageInputModel> image);
        Task<byte[]?> GetImageAsync(Guid id);
    }
}
