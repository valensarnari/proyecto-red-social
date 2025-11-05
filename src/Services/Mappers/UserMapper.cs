using Models.Entities;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                DisplayName = user.DisplayName,
                Bio = user.Bio,
                JoinedIn = user.JoinedIn,
                ProfileImageUrl = user.ProfileImageUrl,
                FollowersCount = user.Followers.Count(),
                FollowingCount = user.Following.Count()
            };
        }

        public static UserSummaryDto ToSummaryDto(this User user)
        {
            return new UserSummaryDto
            {
                Id = user.Id,
                Username = user.Username,
                DisplayName = user.DisplayName,
                ProfileImageUrl = user.ProfileImageUrl
            };
        }
    }
}
