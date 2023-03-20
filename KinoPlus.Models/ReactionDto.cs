using System;

namespace KinoPlus.Models
{
    public class ReactionDto
    {
        public int Id { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}