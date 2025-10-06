using Data;
using Services.DTOs.Users;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Users
{
    public class GetUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Execute(Guid userId)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            return user.ToDto();
        }
    }
}
