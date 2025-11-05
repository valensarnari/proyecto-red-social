using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Posts;
using Services.UseCases.Likes;
using Services.UseCases.Posts;
using Services.UseCases.Reposts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostUseCases _postUseCases;
        private readonly RepostUseCases _repostUseCases;
        private readonly LikeUseCases _likeUseCases;

        public PostsController(PostUseCases postUseCases, RepostUseCases repostUseCases, LikeUseCases likeUseCases)
        {
            _postUseCases = postUseCases;
            _repostUseCases = repostUseCases;
            _likeUseCases = likeUseCases;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPost([FromRoute] Guid id)
        {
            var post = await _postUseCases.GetPost.Execute(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var createdPost = await _postUseCases.CreatePost.Execute(request, userId);
            return CreatedAtAction(nameof(GetPost), new {id = createdPost.Id}, createdPost);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePost([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var deleted = await _postUseCases.DeletePost.Execute(id, userId);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id:guid}/reply")]
        public async Task<IActionResult> CreateReply([FromRoute] Guid id, [FromBody] string content)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var createdReply = await _postUseCases.CreateReply.Execute(new CreateReplyRequest { Content = content, ParentPostId = id}, userId);
            return CreatedAtAction(nameof(GetPost), new { id = createdReply.Id }, createdReply);
        }

        [HttpGet("{id:guid}/replies")]
        public async Task<IActionResult> GetReplies([FromRoute] Guid id)
        {
            var replies = await _postUseCases.GetPostReplies.Execute(id);
            if (replies == null)
            {
                return NotFound();
            }

            return Ok(replies);
        }

        [HttpPost("{id:guid}/quote")]
        public async Task<IActionResult> CreateQuote([FromRoute] Guid id, [FromBody] string content)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var createdQuote = await _postUseCases.CreateQuote.Execute(new CreateQuoteRequest { Content = content, QuotedPostId = id}, userId);
            return CreatedAtAction(nameof(GetPost), new { id = createdQuote.Id }, createdQuote);
        }

        [HttpPost("{id:guid}/repost")]
        public async Task<IActionResult> CreateRepost([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var createdRepost = await _repostUseCases.CreateRepost.Execute(id, userId);
            return Ok(createdRepost);
        }

        [HttpDelete("{id:guid}/repost")]
        public async Task<IActionResult> DeleteRepost([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var deleted = await _repostUseCases.DeleteRepost.Execute(id, userId);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id:guid}/reposts")]
        public async Task<IActionResult> GetReposts([FromRoute] Guid id)
        {
            var reposts = await _repostUseCases.GetRepostsByPost.Execute(id);
            if (reposts == null)
            {
                return NotFound();
            }

            return Ok(reposts);
        }

        [HttpPost("{id:guid}/like")]
        public async Task<IActionResult> CreateLike([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var createdLike = await _likeUseCases.CreateLike.Execute(id, userId);
            return Ok(createdLike);
        }

        [HttpDelete("{id:guid}/like")]
        public async Task<IActionResult> DeleteLike([FromRoute] Guid id)
        {
            var userId = Guid.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                User.FindFirstValue(JwtRegisteredClaimNames.Sub)!
            );

            var deleted = await _likeUseCases.DeleteLike.Execute(id, userId);
            if (deleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id:guid}/likes")]
        public async Task<IActionResult> GetLikes([FromRoute] Guid id)
        {
            var likes = await _likeUseCases.GetLikesByPost.Execute(id);
            if (likes == null)
            {
                return NotFound();
            }

            return Ok(likes);
        }
    }
}
