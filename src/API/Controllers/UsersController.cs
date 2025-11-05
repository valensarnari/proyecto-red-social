using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services.UseCases.Follows;
using Services.UseCases.Likes;
using Services.UseCases.Posts;
using Services.UseCases.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FollowUseCases _followUseCases;
        private readonly UserUseCases _userUseCases;
        private readonly LikeUseCases _likeUseCases;
        private readonly PostUseCases _postUseCases;

        public UsersController(LikeUseCases likeUseCases, UserUseCases userUseCases, FollowUseCases followUseCases, PostUseCases postUseCases)
        {
            _likeUseCases = likeUseCases;
            _userUseCases = userUseCases;
            _followUseCases = followUseCases;
            _postUseCases = postUseCases;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByUsername([FromQuery] string query)
        {
            var users = await _userUseCases.GetUsers.Execute(query);

            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var user = await _userUseCases.GetUser.Execute(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{id:guid}/followers")]
        public async Task<IActionResult> GetFollowers([FromRoute] Guid id)
        {
            var followers = await _followUseCases.GetFollowers.Execute(id);

            if (followers == null)
            {
                return NotFound();
            }

            return Ok(followers);
        }

        [HttpGet("{id:guid}/following")]
        public async Task<IActionResult> GetFollowing([FromRoute] Guid id)
        {
            var following = await _followUseCases.GetFollowing.Execute(id);

            if (following == null)
            {
                return NotFound();
            }

            return Ok(following);
        }

        [HttpPost("{id:guid}/follow")]
        public async Task<IActionResult> CreateFollow([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var follow = await _followUseCases.CreateFollow.Execute(userId, id);
            return Ok(follow);
        }

        [HttpDelete("{id:guid}/follow")]
        public async Task<IActionResult> DeleteFollow([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var follow = await _followUseCases.DeleteFollow.Execute(id, userId);
            if (follow == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id:guid}/posts")]
        public async Task<IActionResult> GetTimeline([FromRoute] Guid id)
        {
            var timeline = await _postUseCases.GetUserTimeline.Execute(id);

            if (timeline == null)
            {
                return NotFound();
            }

            return Ok(timeline);
        }

        [HttpGet("{id:guid}/likes")]
        public async Task<IActionResult> GetLikes([FromRoute] Guid id)
        {
            var likes = await _likeUseCases.GetLikesByUser.Execute(id);

            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }
    }
}
