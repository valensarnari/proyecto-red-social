using Data;
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

        public async Task<bool> Execute(CreateRepostRequest request)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(request.PostId);
            var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);

            if (post == null || user == null)
            {
                // return false;
                throw new KeyNotFoundException("Post or User not found.");
            }

            await _unitOfWork.Reposts.CreateAsync(request.ToEntity());
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
