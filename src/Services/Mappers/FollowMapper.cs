using Models.Entities;
using Services.DTOs.Follows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class FollowMapper
    {
        public static FollowDto ToDto(this Follow follow)
        {
            return new FollowDto
            {
                Id = follow.Id,
                Follower = follow.Follower.ToSummaryDto(),
                Followed = follow.Follower.ToSummaryDto(),
                Date = follow.Date
            };
        }
    }
}
