using Services.DTOs.Posts;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Reposts
{
    public class RepostDto
    {
        public Guid Id { get; set; }
        public UserSummaryDto User { get; set; }
        public PostSummaryDto Post { get; set; }
        public DateTime SharedOn { get; set; }
    }
}
