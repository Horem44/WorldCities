using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Identity;

namespace WorldCities.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<ApplicationUser> GetUsers() => _userManager.Users;

        public async Task<ApplicationUser?> GetCurrentUser()
        {
            string? id = GetCurrentUserId().ToString();

            return id == null ? null : await FindById(id);
        }

        public Guid? GetCurrentUserId()
        {
            string? id = _httpContextAccessor.HttpContext?.User.FindFirstValue(
                ClaimTypes.NameIdentifier
            );

            return id == null ? null : Guid.Parse(id);
        }

        public Task<ApplicationUser?> FindByEmail(string email) =>
            _userManager.FindByEmailAsync(email);

        public Task<ApplicationUser?> FindById(string id) => _userManager.FindByIdAsync(id);

        public Task<IdentityResult> Create(ApplicationUser user, string password) =>
            _userManager.CreateAsync(user, password);

        public Task<IdentityResult> Update(ApplicationUser user) => _userManager.UpdateAsync(user);
    }
}
