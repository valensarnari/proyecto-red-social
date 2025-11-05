using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUnitOfWork
    {
        IFollowRepository Follows { get; }
        ILikeRepository Likes { get; }
        IPostRepository Posts { get; }
        IRepostRepository Reposts { get; }
        IUserRepository Users { get; }

        Task<int> SaveChangesAsync();
    }
}
