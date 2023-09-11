using System;

namespace KinoPlus.Models
{
    public class FITPasosDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsValid { get; set; }
    }
}
