using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Likes
{
    public class DeleteLike
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLike(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid likeId, Guid userId)
        {
            var like = await _unitOfWork.Likes.GetByIdAsync(likeId);
            if (like == null)
            {
                // return false;
                throw new KeyNotFoundException("Like not found.");
            }

            if (like.UserId != userId)
            {
                // return false;
                throw new InvalidOperationException("This user cannot delete the like.");
            }

            var post = await _unitOfWork.Posts.GetByIdAsync(like.PostId);
            post.TotalLikes--;
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.Likes.DeleteAsync(likeId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
