using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Users
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
