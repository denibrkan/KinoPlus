using System;
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
        public string TrailerUrl { get; set; }
        [Required]
        public Guid? ImageId { get; set; }
        [Required]
        public int? YearId { get; set; }
        [Required]
        public int? StatusId { get; set; }
        public int[] CategoryIds { get; set; } = new int[0];
        public int[] ActorIds { get; set; } = new int[0];
        public int[] GenreIds { get; set; } = new int[0];
    }
}
