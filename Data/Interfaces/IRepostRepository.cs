using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepostRepository : IBaseRepository<Repost>
    {
        Task<bool> Exists(Guid userId, Guid postId);
        Task<IEnumerable<Repost>> GetByPost(Guid postId);
    }
}
