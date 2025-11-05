using Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Repost : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public DateTime SharedOn { get; set; } = DateTime.Now;

        public virtual Post Post { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
