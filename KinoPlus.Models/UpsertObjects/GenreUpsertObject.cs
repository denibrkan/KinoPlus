using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class GenreUpsertObject
    {
        [Required]
        public string Name { get; set; }
    }
}
