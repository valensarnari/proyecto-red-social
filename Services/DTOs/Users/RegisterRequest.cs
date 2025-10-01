using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; } 
        public string PasswordHash { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
