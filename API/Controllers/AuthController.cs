using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Users;
using Services.UseCases.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(UserUseCases users) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var token = await users.Register.Execute(request);
            return Ok(new { token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await users.Login.Execute(request);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var user = await users.GetUser.Execute(userId);
            return Ok(user);
        }
    }
}
