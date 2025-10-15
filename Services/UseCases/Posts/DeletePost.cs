using Data;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Posts
{
    public class DeletePost
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid postId, Guid userId)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(postId);
            if (post == null)
            {
                // return false;
                throw new KeyNotFoundException("Post not found.");
            }

            if (post.UserId != userId)
            {
                // return false;
                throw new InvalidOperationException("This user cannot delete the post.");
            }

            await _unitOfWork.Posts.DeleteAsync(postId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
