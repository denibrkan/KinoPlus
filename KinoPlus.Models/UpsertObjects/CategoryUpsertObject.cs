using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class CategoryUpsertObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrderPoints { get; set; }
        [Required]
        public bool IsDisplayed { get; set; }
        public int[] MovieIds { get; set; } = new int[0];
    }
}
