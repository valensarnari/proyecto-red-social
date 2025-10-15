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
    public class RepostRepository : BaseRepository<Repost>, IRepostRepository
    {
        private readonly ApplicationContext _context;

        public RepostRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(Guid userId, Guid postId)
        {
            var repost = await _context.Reposts.FirstOrDefaultAsync(r => r.UserId == userId && r.PostId == postId);
            if (repost == null)
            {
                return false;
            }

            return true;
        }
    }
}
