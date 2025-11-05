using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Posts
{
    public class CreateQuoteRequest
    {
        public string Content { get; set; }
        public Guid QuotedPostId { get; set; }
    }
}
