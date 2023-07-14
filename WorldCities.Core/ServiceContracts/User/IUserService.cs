using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.DTO.User;

namespace WorldCities.Core.ServiceContracts.User
{
    public interface IUserService
    {
        Task<List<UserResponse>> GetFilteredUsers(string personName);
    }
}
