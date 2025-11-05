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
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        private readonly ApplicationContext _context;

        public LikeRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid userId, Guid postId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(r => r.UserId == userId && r.PostId == postId);
            if (like == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Like>> GetByPost(Guid postId)
            => await _context.Likes.Where(l => l.PostId == postId).OrderByDescending(l => l.LikedOn).ToListAsync();

        public async Task<IEnumerable<Like>> GetByUser(Guid userId)
            => await _context.Likes.Where(l => l.UserId == userId).Include(l => l.Post).OrderByDescending(l => l.LikedOn).ToListAsync();
    }
}
