using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class CurrentService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue(ClaimTypes.NameIdentifier) ??
                    _httpContextAccessor.HttpContext?.User?
                    .FindFirstValue(JwtRegisteredClaimNames.Sub);
                return id != null ? Guid.Parse(id) : null;
            }
        }

        public string? Username =>
            _httpContextAccessor.HttpContext?.User?
                .FindFirstValue(JwtRegisteredClaimNames.UniqueName);
    }
}
