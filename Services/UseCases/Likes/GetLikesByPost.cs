using Data;
using Models.Entities;
using Services.DTOs.Likes;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Likes
{
    public class GetLikesByPost
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLikesByPost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LikeDto>> Execute(Guid postId)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(postId);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }

            var likes = await _unitOfWork.Likes.GetByPost(postId);
            return likes.Select(l => l.ToDto());
        }
    }
}
