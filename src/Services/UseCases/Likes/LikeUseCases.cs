using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Likes
{
    public record class LikeUseCases
    (
        CreateLike CreateLike,
        DeleteLike DeleteLike,
        GetLikesByUser GetLikesByUser,
        GetLikesByPost GetLikesByPost
    );
}
