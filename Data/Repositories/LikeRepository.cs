using Data.Interfaces;
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
    }
}
