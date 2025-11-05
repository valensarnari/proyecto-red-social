using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Reposts
{
    public class DeleteRepost
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRepost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Execute(Guid repostId, Guid userId)
        {
            var repost = await _unitOfWork.Reposts.GetByIdAsync(repostId);
            if (repost == null)
            {
                return null;
                // throw new KeyNotFoundException("Repost not found.");
            }

            if (repost.UserId != userId)
            {
                // return false;
                throw new InvalidOperationException("This user cannot delete the repost.");
            }

            var post = await _unitOfWork.Posts.GetByIdAsync(repost.PostId);
            post.TotalReposts--;
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.Reposts.DeleteAsync(repostId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
