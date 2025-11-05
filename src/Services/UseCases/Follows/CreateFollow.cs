using Data;
using Models.Entities;
using Services.DTOs.Follows;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Follows
{
    public class CreateFollow
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFollow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FollowDto> Execute(Guid followerId, Guid followedId)
        {
            var follower = await _unitOfWork.Users.GetByIdAsync(followerId);
            var followed = await _unitOfWork.Users.GetByIdAsync(followedId);

            if (follower == null || followed == null)
            {
                // return false;
                throw new KeyNotFoundException("User/s not found.");
            }

            if (followerId == followedId)
            {
                // return false;
                throw new InvalidOperationException("You cannot follow you.");
            }

            if (await _unitOfWork.Follows.Exists(followerId, followedId))
            {
                // return false;
                throw new InvalidOperationException("Follow already exists.");
            }
            
            var createdFollow = await _unitOfWork.Follows.CreateAsync(new Follow { FollowerId = followerId, FollowedId = followedId });
            await _unitOfWork.SaveChangesAsync();
            return createdFollow.ToDto();
        }
    }
}
