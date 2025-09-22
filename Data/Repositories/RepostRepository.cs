using Data.Interfaces;
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
    }
}
