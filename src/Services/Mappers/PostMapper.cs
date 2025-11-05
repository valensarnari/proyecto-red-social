using Models.Entities;
using Services.DTOs.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class PostMapper
    {
        public static Post ToEntity(this CreatePostRequest request, Guid userId)
        {
            return new Post
            {
                Content = request.Content,
                UserId = userId
            };
        }

        public static Post ToEntity(this CreateReplyRequest request, Guid userId)
        {
            return new Post
            {
                Content = request.Content,
                UserId = userId,
                ParentPostId = request.ParentPostId
            };
        }

        public static Post ToEntity(this CreateQuoteRequest request, Guid userId)
        {
            return new Post
            {
                Content = request.Content,
                UserId = userId,
                QuotedPostId = request.QuotedPostId
            };
        }

        public static PostDto ToDto(this Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Content = post.Content,
                PostedOn = post.PostedOn,
                User = post.User.ToSummaryDto(),
                ParentPostId = post.ParentPostId,
                QuotedPost = post.QuotedPostId != null ? post.QuotedPost.ToSummaryDto() : null,
                LikesCount = post.TotalLikes,
                RepostsCount = post.TotalReposts,
                RepliesCount = post.TotalComments,
                Type = post.ParentPostId != null ? "reply" : post.QuotedPostId == null ? "post" : "quote"
            };
        }

        public static PostSummaryDto ToSummaryDto(this Post post)
        {
            return new PostSummaryDto
            {
                Id = post.Id,
                Content = post.Content,
                PostedOn = post.PostedOn,
                User = post.User.ToSummaryDto()
            };
        }
    }
}
