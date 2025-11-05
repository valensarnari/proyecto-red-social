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
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async override Task<Post?> GetByIdAsync(Guid id)
            => await _context.Posts
                .Include(p => p.User)
                .Include(p => p.ParentPost)
                .Include(p => p.QuotedPost)
                .FirstOrDefaultAsync(p => p.Id == id);

        // Ordenados por fecha
        public async Task<IEnumerable<Post>> GetQuotes(Guid postId)
            => await _context.Posts.Where(p => p.QuotedPostId == postId).OrderByDescending(p => p.PostedOn).ToListAsync();

        // Ordenados por likes
        public async Task<IEnumerable<Post>> GetReplies(Guid postId)
            => await _context.Posts.Where(p => p.ParentPostId == postId).OrderByDescending(p => p.TotalLikes).ToListAsync();
    }
}
