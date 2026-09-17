using AuthSecurity.Infrastructure;
using AuthSecurity.Models;
using AuthSecurity.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace AuthSecurity.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IList<User> users, ITokenService tokenService) : ControllerBase
    {
        private readonly IList<User> _users = users;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User? user = _users.SingleOrDefault(u => u.Email == dto.Email);

            if(user is null)
                return NotFound();

            string token = _tokenService.GenerateToken(user);
            user.RefreshToken = _tokenService.GenerateRefreshToken();

            return Ok(new UserDto(user.Id, user.Nom, user.Prenom, user.Email, user.Role, token, user.RefreshToken));
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public IActionResult Refresh(RefreshTokenDto dto)
        {
            int id = _tokenService.GetUserIdFrom(dto.Token);

            User? user = _users.SingleOrDefault(u => u.Id  == id);

            if (user is null)
                return BadRequest();

            if (user.RefreshToken != dto.RefreshToken)
                return BadRequest();

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            string token = _tokenService.GenerateToken(user);

            return Ok(new TokenPairDto(token, user.RefreshToken));
        }
    }
}
