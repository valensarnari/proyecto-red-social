using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetReplies(Guid postId);
        Task<IEnumerable<Post>> GetQuotes(Guid postId);
    }
}
