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
    public class GetFeed
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFeed(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostDto>?> Execute(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
                // throw new KeyNotFoundException("User not found.");
            }

            var feed = await _unitOfWork.Users.GetFeed(userId);
            var postDtos = feed.Cast<Post>().Select(PostMapper.ToDto).ToList();
            return postDtos;
        }
    }
}
