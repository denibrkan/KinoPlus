using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace KinoPlus.Services
{
    public class ImageService : IImageService
    {
        private const int ThumbnailWidth = 155;
        private readonly Database.KinoplusContext _context;

        public ImageService(Database.KinoplusContext context)
        {
            _context = context;
        }


        public async Task<List<Guid>> ProcessAsync(IEnumerable<ImageInputModel> images)
        {
            //create copies of desired sizes and save as jpeg
            var imageIds = new List<Guid>();

            foreach (var image in images)
            {
                using var imageResult = await Image.LoadAsync(image.Content);

                var original = await SaveImageAsync(imageResult, imageResult.Width);
                var thumbnail = await SaveImageAsync(imageResult, ThumbnailWidth);

                //save to db
                var dbImage = new Database.Image
                {
                    Name = image.FileName,
                    Type = image.Type,
                    OriginalContent = original,
                    ThumbnailContent = thumbnail
                };
                _context.Images.Add(dbImage);
                await _context.SaveChangesAsync();

                imageIds.Add(dbImage.Id);
            }

            return imageIds;
        }

        private async Task<byte[]> SaveImageAsync(Image image, int resizeWidth)
        {
            var width = image.Width;
            var height = image.Height;

            if (width > resizeWidth)
            {
                height = (int)((double)resizeWidth / width * height);
                width = resizeWidth;
            }

            image.Mutate(x => x.Resize(width, height));
            image.Metadata.ExifProfile = null;

            var memoryStream = new MemoryStream();

            await image.SaveAsJpegAsync(memoryStream, new JpegEncoder
            {
                Quality = 80
            });

            return memoryStream.ToArray();
        }

        public async Task<byte[]?> GetImageAsync(Guid id, bool original)
        {
            if (original)
            {
                return await _context.Images.Where(i => i.Id == id).Select(i => i.OriginalContent).SingleOrDefaultAsync();
            }

            return await _context.Images.Where(i => i.Id == id).Select(i => i.ThumbnailContent).SingleOrDefaultAsync();
        }

    }
}
