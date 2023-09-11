using System;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models.UpsertObjects
{
    public class FITPasosUpsertObject
    {
        [Required]
        public DateTime? ValidUntil { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public bool? IsValid { get; set; }
    }
}
