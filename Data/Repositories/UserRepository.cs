using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        // Incluye posts, reposts y replies de los usuarios que sigue (incluido el mismo), ordenados cronologicamente
        public async Task<IEnumerable<object>> GetFeed(Guid userId)
        {
            // Consigo los ids de los seguidores del usuario e incluyo al usuario mismo
            var followingIds = await _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.FollowedId).ToListAsync();
            followingIds.Add(userId);

            // Traer posts y replies
            var posts = _context.Posts
                .Where(p => followingIds.Contains(p.UserId))
                .Select(p => new
                {
                    Post = p,
                    Date = p.PostedOn,
                    Type = p.ParentPostId == null ? "post" : "reply"
                });

            // Traer reposts
            var reposts = _context.Reposts
                .Where(r => followingIds.Contains(r.UserId))
                .Select(r => new
                {
                    Post = r.Post,
                    Date = r.SharedOn,
                    Type = "repost"
                });

            var feed = await posts.Union(reposts).OrderByDescending(x => x.Date).ToListAsync();

            return feed.Select(x => x.Post);
        }

        public async Task<IEnumerable<User>> GetFollowers(Guid userId)
            => await _context.Follows.Where(f => f.FollowedId == userId).Select(f => f.Followed).ToListAsync();

        public async Task<IEnumerable<User>> GetFollowing(Guid userId)
            => await _context.Follows.Where(f => f.FollowerId == userId).Select(f => f.Follower).ToListAsync();

        public async Task<IEnumerable<Post>> GetLikes(Guid userId)
            => await _context.Likes.Where(l => l.UserId == userId).OrderByDescending(l => l.LikedOn).Select(l => l.Post).ToListAsync();

        public async Task<IEnumerable<object>> GetPosts(Guid userId)
        {
            // Traer posts
            var posts = _context.Posts
                .Where(p => p.UserId == userId && p.ParentPostId == null)
                .Select(p => new
                {
                    Post = p,
                    Date = p.PostedOn,
                    Type = "post"
                });

            // Traer reposts
            var reposts = _context.Reposts
                .Where(r => r.UserId == userId)
                .Select(r => new
                {
                    Post = r.Post,
                    Date = r.SharedOn,
                    Type = "repost"
                });

            var timeline = await posts.Union(reposts).OrderByDescending(x => x.Date).ToListAsync();

            return timeline.Select(x => x.Post);
        }

        public async Task<IEnumerable<object>> GetReplies(Guid userId)
        {
            // Traer posts y replies
            var posts = _context.Posts
                .Where(p => p.UserId == userId)
                .Select(p => new
                {
                    Post = p,
                    Date = p.PostedOn,
                    Type = p.ParentPostId == null ? "post" : "reply"
                });

            // Traer reposts
            var reposts = _context.Reposts
                .Where(r => r.UserId == userId)
                .Select(r => new
                {
                    Post = r.Post,
                    Date = r.SharedOn,
                    Type = "repost"
                });

            var timeline = await posts.Union(reposts).OrderByDescending(x => x.Date).ToListAsync();

            return timeline.Select(x => x.Post);
        }
    }
}
