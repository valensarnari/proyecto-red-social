using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Posts
{
    public class CreateReplyRequest
    {
        public string Content { get; set; }
        public Guid ParentPostId { get; set; }
    }
}
