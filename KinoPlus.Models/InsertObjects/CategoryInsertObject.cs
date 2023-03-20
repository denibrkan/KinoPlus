using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class CategoryInsertObject
    {
        [Required]
        public string Name { get; set; }
    }
}
