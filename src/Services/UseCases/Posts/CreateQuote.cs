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
    public class CreateQuote
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateQuote(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PostDto> Execute(CreateQuoteRequest request, Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var createdQuote = await _unitOfWork.Posts.CreateAsync(request.ToEntity(userId));

            var quotedPost = await _unitOfWork.Posts.GetByIdAsync(createdQuote.QuotedPostId.Value);
            quotedPost.TotalReposts++;
            await _unitOfWork.Posts.UpdateAsync(quotedPost);

            await _unitOfWork.SaveChangesAsync();
            return createdQuote.ToDto();
        }
    }
}
