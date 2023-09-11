using System;

namespace KinoPlus.Models
{
    public class FITPasosSearchObject : BaseSearchObject
    {
        public int? UserId { get; set; }
        public DateTime? ValidUntil { get; set; }
    }
}
