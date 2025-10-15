using Data;
using Services.DTOs.Posts;
using Services.Mappers;
using Services.UseCases.Reposts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Posts
{
    public class CreateReply
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateReply(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDto> Execute(CreateReplyRequest request, Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var createdReply = await _unitOfWork.Posts.CreateAsync(request.ToEntity(userId));
            
            var parentPost = await _unitOfWork.Posts.GetByIdAsync(createdReply.ParentPostId.Value);
            parentPost.TotalComments++;
            await _unitOfWork.Posts.UpdateAsync(parentPost);

            await _unitOfWork.SaveChangesAsync();
            return createdReply.ToDto();
        }
    }
}
