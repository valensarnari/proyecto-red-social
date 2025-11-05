using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Posts
{
    public class PostSummaryDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public UserSummaryDto User { get; set; }
    }
}
