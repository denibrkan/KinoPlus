using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class CategoryUpdateObject
    {
        [Required]
        public string Name { get; set; }
    }
}
