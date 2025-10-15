using Data;
using Models.Entities;
using Services.DTOs.Posts;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Posts
{
    public class CreatePost
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDto> Execute(CreatePostRequest request, Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var createdPost = await _unitOfWork.Posts.CreateAsync(request.ToEntity(userId));
            await _unitOfWork.SaveChangesAsync();
            return createdPost.ToDto();
        }
    }
}
