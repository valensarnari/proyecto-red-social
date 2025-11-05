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
    public class FollowRepository : BaseRepository<Follow>, IFollowRepository
    {
        private readonly ApplicationContext _context;

        public FollowRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid followerId, Guid followedId)
        {
            var follow = await _context.Follows.FirstOrDefaultAsync(f => f.FollowerId == followerId && f.FollowedId == followedId);
            if (follow == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Follow>> GetFollowersByUser(Guid userId)
            => await _context.Follows.Where(f => f.FollowedId == userId).Include(f => f.Follower).Include(f => f.Followed).ToListAsync();

        public async Task<IEnumerable<Follow>> GetFollowingByUser(Guid userId)
            => await _context.Follows.Where(f => f.FollowerId == userId).Include(f => f.Follower).Include(f => f.Followed).ToListAsync();
    }
}
