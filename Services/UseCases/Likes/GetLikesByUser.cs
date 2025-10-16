using Data;
using Services.DTOs.Likes;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Likes
{
    public class GetLikesByUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLikesByUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LikeDto>> Execute(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            var likes = await _unitOfWork.Likes.GetByUser(userId);
            return likes.Select(l => l.ToDto());
        }
    }
}
