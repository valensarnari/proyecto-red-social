using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Reposts
{
    public class DeleteRepost
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRepost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid repostId)
        {
            var repost = await _unitOfWork.Reposts.GetByIdAsync(repostId);
            if (repost == null)
            {
                return false;
                // throw new KeyNotFoundException("Repost not found.");
            }

            await _unitOfWork.Reposts.DeleteAsync(repostId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
