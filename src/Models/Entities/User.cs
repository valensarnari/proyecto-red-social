using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime JoinedIn { get; set; } = DateTime.Now;
        public string ProfileImageUrl { get; set; } = null!;

        public virtual ICollection<Follow> Followers { get; set; } = new List<Follow>(); // Mis seguidores
        public virtual ICollection<Follow> Following { get; set; } = new List<Follow>(); // Los que sigo
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<Repost> Reposts { get; set; } = new List<Repost>();
    }
}
