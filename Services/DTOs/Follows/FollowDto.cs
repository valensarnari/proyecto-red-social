using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Follows
{
    public class FollowDto
    {
        public Guid Id { get; set; }
        public UserSummaryDto Follower { get; set; }
        public UserSummaryDto Followed { get; set; }
        public DateTime Date { get; set; }
    }
}
