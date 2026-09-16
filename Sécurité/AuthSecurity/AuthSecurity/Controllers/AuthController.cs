using AuthSecurity.Models;
using AuthSecurity.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AuthSecurity.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IList<User> users) : ControllerBase
    {
        private readonly IList<User> _users = users;

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User? user = _users.SingleOrDefault(u => u.Email == dto.Email);

            if(user is null)
                return NotFound();

            return Ok(user);
        }
    }
}
