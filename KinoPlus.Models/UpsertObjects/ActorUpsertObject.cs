using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class ActorUpsertObject
    {
        [Required]
        public string Name { get; set; }
    }
}
