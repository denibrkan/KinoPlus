using System.IO;

namespace KinoPlus.Models
{
    public class ImageInputModel
    {
        public string FileName { get; set; }
        public string Type { get; set; }
        public Stream Content { get; set; }
    }
}
