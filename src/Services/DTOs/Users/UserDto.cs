using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public DateTime JoinedIn { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
    }
}
