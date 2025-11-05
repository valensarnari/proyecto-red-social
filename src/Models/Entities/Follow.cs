using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public virtual User Follower { get; set; } = null!; // Usuario que sigue a
        public virtual User Followed { get; set; } = null!; // Usuario que es seguido
    }
}
