using Data;
using Models.Entities;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Users
{
    public class Register
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtService _jwt;

        public Register(IUnitOfWork unitOfWork, JwtService jwt)
        {
            _unitOfWork = unitOfWork;
            _jwt = jwt;
        }

        public async Task<string> Execute(RegisterRequest request)
        {
            var existingUser = await _unitOfWork.Users.GetByUsername(request.Username);
            if (existingUser != null)
                throw new InvalidOperationException("Invalid Username.");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash),
                DisplayName = request.DisplayName,
                Bio = request.Bio,
                ProfileImageUrl = request.ProfileImageUrl ?? "images/default"
            };

            await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _jwt.GenerateToken(user.Id, user.Username);
        }
    }
}
