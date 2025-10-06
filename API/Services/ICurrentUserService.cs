using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICurrentUserService
    {
        Guid? UserId { get; }
        string? Username { get; }
    }
}
