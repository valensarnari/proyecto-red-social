using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Posts
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }

        public UserSummaryDto User { get; set; }

        public Guid? ParentPostId { get; set; }
        public PostSummaryDto? QuotedPost { get; set; }

        public int LikesCount { get; set; }
        public int RepostsCount { get; set; }
        public int RepliesCount { get; set; }

        public string Type { get; set; }
    }
}
