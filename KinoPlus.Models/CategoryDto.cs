using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderPoints { get; set; }
        public bool IsDisplayed { get; set; }
        public List<CategoryMovieDto> Movies { get; set; }
    }

}