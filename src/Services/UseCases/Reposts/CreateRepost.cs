using Data;
using Models.Entities;
using Services.DTOs.Reposts;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Reposts
{
    public class CreateRepost
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRepost(IUnitOfWork unitOfWork)
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

            if (await _unitOfWork.Reposts.Exists(userId, postId))
            {
                // return false;
                throw new InvalidOperationException("Repost already exists.");
            }

            post.TotalReposts++;
            await _unitOfWork.Posts.UpdateAsync(post);
            await _unitOfWork.Reposts.CreateAsync(new Repost { PostId = postId, UserId = userId});
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
