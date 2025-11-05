using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IFollowRepository Follows { get; }
        public ILikeRepository Likes { get; }
        public IPostRepository Posts { get; }
        public IRepostRepository Reposts { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationContext context, IFollowRepository follows, ILikeRepository likes, IPostRepository posts, IRepostRepository reposts, IUserRepository users)
        {
            _context = context;
            Follows = follows;
            Likes = likes;
            Posts = posts;
            Reposts = reposts;
            Users = users;
        }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
