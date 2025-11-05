using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.UseCases.Posts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/feed")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly PostUseCases _postUseCases;

        public FeedController(PostUseCases postUseCases)
        {
            _postUseCases = postUseCases;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeed()
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var feed = await _postUseCases.GetFeed.Execute(userId);
            if (feed == null)
            {
                return NotFound();
            }

            return Ok(feed);
        }
    }
}
