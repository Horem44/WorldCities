using Microsoft.AspNetCore.Identity;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> FindByEmail(string email);
        Task<ApplicationUser?> FindById(string id);
        Task<IdentityResult> Create(ApplicationUser user, string password);
        IQueryable<ApplicationUser> GetUsers();
    }
}
