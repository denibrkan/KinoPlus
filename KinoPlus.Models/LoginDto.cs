using KinoPlus.Common.Resources.Strings;
using System.ComponentModel.DataAnnotations;

namespace KinoPlus.Models
{
    public class LoginDto
    {
        [Required(ErrorMessageResourceName = nameof(Strings.UsernameRequired), ErrorMessageResourceType = typeof(Strings))]
        public string Username { get; set; }
        [Required(ErrorMessageResourceName = nameof(Strings.PasswordRequired), ErrorMessageResourceType = typeof(Strings))]
        public string Password { get; set; }
    }
}
