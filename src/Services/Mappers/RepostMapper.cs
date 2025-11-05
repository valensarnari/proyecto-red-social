using Models.Entities;
using Services.DTOs.Reposts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class RepostMapper
    {
        public static RepostDto ToDto(this Repost repost)
        {
            return new RepostDto
            {
                Id = repost.Id,
                Post = repost.Post.ToSummaryDto(),
                User = repost.User.ToSummaryDto(),
                SharedOn = repost.SharedOn
            };
        }
    }
}
