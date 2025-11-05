using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UseCases.Users
{
    public record class UserUseCases
    (
        Login Login,
        Register Register,
        GetUser GetUser,
        GetUsers GetUsers
    );
}
