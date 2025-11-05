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
    public class GetUsers
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserSummaryDto>> Execute(string query)
        {
            var users = await _unitOfWork.Users.SearchUsers(query);
            return users.Select(u => u.ToSummaryDto());
        }
    }
}
