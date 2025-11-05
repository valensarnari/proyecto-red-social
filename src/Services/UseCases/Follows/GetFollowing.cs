using Data;
using Services.DTOs.Follows;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Follows
{
    public class GetFollowing
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFollowing(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FollowDto>?> Execute(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
                // throw new KeyNotFoundException("User not found.");
            }

            var following = await _unitOfWork.Follows.GetFollowingByUser(userId);
            return following.Select(f => f.ToDto());
        }
    }
}
