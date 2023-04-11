using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MovieDto> Movies { get; set; }
    }
}