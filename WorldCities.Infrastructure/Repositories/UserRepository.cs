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

        public IQueryable<ApplicationUser> GetUsers() => _userManager.Users;

        public Task<ApplicationUser?> FindByEmail(string email) =>
            _userManager.FindByEmailAsync(email);

        public Task<ApplicationUser?> FindById(string id) => _userManager.FindByIdAsync(id);

        public Task<IdentityResult> Create(ApplicationUser user, string password) =>
            _userManager.CreateAsync(user, password);

        public Task<IdentityResult> Update(ApplicationUser user) => _userManager.UpdateAsync(user);
    }
}
