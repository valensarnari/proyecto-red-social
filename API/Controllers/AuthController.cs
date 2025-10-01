using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok("");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok("");
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            return Ok("");
        }
    }
}
