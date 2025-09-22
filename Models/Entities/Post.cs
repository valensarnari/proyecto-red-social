using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; } = null!;
        public DateTime PostedOn { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
        public Guid? ParentPostId { get; set; } // Si no es null, es una reply
        public Guid? QuotedPostId { get; set; } // Si no es null, es una quote
        public int TotalLikes { get; set; }
        public int TotalReposts { get; set; }
        public int TotalComments { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Post? ParentPost { get; set; }
        public virtual Post? QuotedPost { get; set; }
        public virtual ICollection<Post> Quotes { get; set; } = new List<Post>();
        public virtual ICollection<Post> Replies { get; set; } = new List<Post>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Repost> Reposts { get; set; } = new List<Repost>();
    }
}
