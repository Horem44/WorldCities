using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Identity;

namespace WorldCities.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<IdentityResult> Create(ApplicationUser user, string password)
        {
            return _userManager.CreateAsync(user, password);
        }

        public Task<ApplicationUser?> FindByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser?> FindById(string id)
        {
            return _userManager.FindByIdAsync(id);
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _userManager.Users;
        }
    }
}
