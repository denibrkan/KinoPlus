using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class MovieReactionUpsertObject
    {
        [Required]
        public int? Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? MovieId { get; set; }
    }
}
