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
    public class GetRepostsByPost
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetRepostsByPost(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RepostDto>> Execute(Guid postId)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(postId);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found.");
            }

            var reposts = await _unitOfWork.Reposts.GetByPost(postId);
            return reposts.Select(l => l.ToDto());
        }
    }
}
