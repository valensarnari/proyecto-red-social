using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IFollowRepository : IBaseRepository<Follow>
    {
        Task<bool> Exists(Guid followerId, Guid followedId);
        Task<IEnumerable<Follow>> GetFollowingByUser(Guid userId);
        Task<IEnumerable<Follow>> GetFollowersByUser(Guid userId);
    }
}
