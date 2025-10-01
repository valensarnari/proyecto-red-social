using Models.Entities;
using Services.DTOs.Reposts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class RepostMapper
    {
        public static Repost ToEntity(this CreateRepostRequest request)
        {
            return new Repost
            {
                PostId = request.PostId,
                UserId = request.UserId,
            };
        }
    }
}
