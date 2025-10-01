using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Reposts
{
    public class CreateRepostRequest
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
