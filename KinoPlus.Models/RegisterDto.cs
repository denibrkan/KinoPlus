using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int LocationId { get; set; }
        public IFormFile Image { get; set; }
    }
}
