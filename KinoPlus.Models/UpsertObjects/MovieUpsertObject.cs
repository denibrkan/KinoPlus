using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class MovieUpsertObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int? Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public string TrailerUrl { get; set; }
        [Required]
        public int? YearId { get; set; }
        public int? StatusId { get; set; }
        public int[] CategoryIds { get; set; }
        public int[] ActorIds { get; set; }
        public int[] GenreIds { get; set; }
    }
}
