using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class LocationUpsertObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public string Address { get; set; }
        public int[] ProjectionTypeIds { get; set; }
        public int[] HallIds { get; set; }
    }
}


