using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Follows
{
    public record class FollowUseCases
    (
        CreateFollow CreateFollow,
        DeleteFollow DeleteFollow,
        GetFollowers GetFollowers,
        GetFollowing GetFollowing
    );
}
