using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Posts
{
    public record class PostUseCases
    (
        CreatePost CreatePost,
        DeletePost DeletePost,
        GetPost GetPost,
        GetUserTimeline GetTimeline,
        GetPostReplies GetReplies,
        CreateReply CreateReply,
        CreateQuote CreateQuote
    );
}
