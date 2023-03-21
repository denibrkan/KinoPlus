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
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService userService, IMapper mapper, ITokenService tokenService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto login)
        {
            var user = await _userService.GetByUsernameAsync(login.Username);

            if (user == null) return Unauthorized("Pogresno korisnicko ime ili password");

            using var hmac = new HMACSHA512(Convert.FromBase64String(user.PasswordSalt));

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            if (user.PasswordHash != Convert.ToBase64String(computedHash))
                return Unauthorized("Pogresno korisnicko ime ili password");

            var korisnik = _mapper.Map<UserDto>(user);

            korisnik.Token = _tokenService.CreateToken(user);

            return korisnik;
        }
    }
}
