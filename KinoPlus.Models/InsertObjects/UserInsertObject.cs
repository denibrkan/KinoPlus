using System;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class UserInsertObject
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
        public string Phone { get; set; }
        public Guid? ImageId { get; set; }
        public int LocationId { get; set; }
        public int[] RoleIds { get; set; }
    }
}
