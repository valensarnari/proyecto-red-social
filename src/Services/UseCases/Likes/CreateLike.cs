using Data;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Likes
{
    public class CreateLike
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLike(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid postId, Guid userId)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(postId);
            var user = await _unitOfWork.Users.GetByIdAsync(userId);

            if (post == null || user == null)
            {
                // return false;
                throw new KeyNotFoundException("Post or User not found.");
            }

            if (await _unitOfWork.Likes.Exists(userId, postId))
            {
                // return false;
                throw new InvalidOperationException("Like already exists.");
            }

            post.TotalLikes++;
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.Likes.CreateAsync(new Like { PostId = postId, UserId = userId });
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
