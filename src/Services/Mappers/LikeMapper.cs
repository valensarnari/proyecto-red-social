using Models.Entities;
using Services.DTOs.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class LikeMapper
    {
        public static LikeDto ToDto(this Like like)
        {
            return new LikeDto
            {
                Id = like.Id,
                Post = like.Post.ToSummaryDto(),
                User = like.User.ToSummaryDto(),
                LikedOn = like.LikedOn
            };
        }
    }
}
