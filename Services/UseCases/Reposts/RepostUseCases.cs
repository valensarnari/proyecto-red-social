using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Reposts
{
    public record class RepostUseCases
    (
        CreateRepost CreateRepost,
        DeleteRepost DeleteRepost
    );
}
