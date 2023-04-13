using System;
using System.Collections.Generic;

namespace KinoPlus.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public Guid? ImageId { get; set; }
        public string Token { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
