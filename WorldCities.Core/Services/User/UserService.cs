using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.DTO.User;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.User;

namespace WorldCities.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserResponse>> GetFilteredUsers(string personName)
        {
            if(string.IsNullOrEmpty(personName))
            {
                return await _userManager.Users
                    .Select(u => u.ToUserResponse())
                    .ToListAsync();
            }
            else
            {
                return await _userManager.Users
                    .Where(u => u.PersonName.Contains(personName))
                    .Select(u => u.ToUserResponse())
                    .ToListAsync();
            }
        }
    }
}
