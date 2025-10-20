using Data;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Follows
{
    public class DeleteFollow
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFollow(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid followId, Guid userId)
        {
            var follow = await _unitOfWork.Follows.GetByIdAsync(followId);
            if (follow == null)
            {
                // return false;
                throw new KeyNotFoundException("Follow not found.");
            }

            if (follow.FollowerId != userId || follow.FollowedId != userId)
            {
                // return false;
                throw new InvalidOperationException("This user cannot delete the follow.");
            }

            await _unitOfWork.Reposts.DeleteAsync(followId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
