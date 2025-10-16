using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        Task<bool> Exists(Guid userId, Guid postId);
        Task<IEnumerable<Like>> GetByUser(Guid userId);
        Task<IEnumerable<Like>> GetByPost(Guid postId);
    }
}
