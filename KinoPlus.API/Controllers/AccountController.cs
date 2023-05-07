using AutoMapper;
using KinoPlus.Models;
using KinoPlus.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace KinoPlus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto login)
        {
            var user = await _userService.GetByUsernameAsync(login.Username);

            if (user == null) return Unauthorized("Pogrešno korisničko ime ili password.");

            using var hmac = new HMACSHA512(Convert.FromBase64String(user.PasswordSalt));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            if (user.PasswordHash != Convert.ToBase64String(computedHash))
                return Unauthorized("Pogresno korisnicko ime ili password");

            var korisnik = _mapper.Map<UserDto>(user);

            korisnik.Token = _tokenService.CreateToken(user);

            return korisnik;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterDto register)
        {
            var user = await _userService.GetByUsernameAsync(register.Username);
            if (user != null) return BadRequest("Korisničko ime već postoji");

            var userInsert = new UserInsertObject
            {
                Username = register.Username,
                Password = register.Password,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Phone = register.PhoneNumber,
            };

            userInsert.RoleIds = (await _userService.GetRoles()).Where(r => r.Name == "Klijent").Select(r => r.Id).ToArray();

            await _userService.InsertAsync(userInsert);

            return Ok("Uspješna registracija");
        }

        [HttpPost("check-username")]
        public async Task<ActionResult<bool>> CheckUsername([FromBody] string username)
        {
            var user = await _userService.GetByUsernameAsync(username);

            if (user == null) return true;

            return false;
        }
    }
}
