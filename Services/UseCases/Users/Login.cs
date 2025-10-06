using Data;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Users
{
    public class Login
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwt;

        public Login(IUnitOfWork unitOfWork, JwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        public async Task<string> Execute(LoginRequest request)
        {
            var user = await _unitOfWork.Users.GetByUsername(request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.PasswordHash, user.PasswordHash))
                throw new UnauthorizedAccessException("User or Password incorrect.");

            return _jwt.GenerateToken(user.Id, user.Username);
        }
    }
}
