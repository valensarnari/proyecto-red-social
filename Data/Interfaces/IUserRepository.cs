using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsername(string username);
        Task<IEnumerable<object>> GetFeed(Guid userId); // Incluye posts, reposts y replies de los usuarios que sigue, ordenados cronologicamente
        Task<IEnumerable<User>> GetFollowers(Guid userId);
        Task<IEnumerable<User>> GetFollowing(Guid userId);
        Task<IEnumerable<object>> GetPosts(Guid userId); // Incluye posts y reposts, ordenados cronologicamente
        Task<IEnumerable<object>> GetReplies(Guid userId); // Incluye posts, reposts y replies, ordenados cronologicamente
        Task<IEnumerable<Post>> GetLikes(Guid userId); // Incluye posts likeados, ordenados cronologicamente
    }
}
