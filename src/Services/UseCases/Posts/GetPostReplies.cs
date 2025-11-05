using Data;
using Services.DTOs.Posts;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Posts
{
    public class GetPostReplies
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPostReplies(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostDto>?> Execute(Guid postId)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(postId);
            if (post == null)
            {
                return null;
                // throw new KeyNotFoundException("Post not found.");
            }

            var replies = await _unitOfWork.Posts.GetReplies(postId);
            return replies.Select(r => r.ToDto());
        }
    }
}
