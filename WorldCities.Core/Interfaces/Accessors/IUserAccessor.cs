using WorldCities.Domain.Identity;

namespace WorldCities.Core.Interfaces.Accessors
{
    public interface IUserAccessor
    {
        public Task<ApplicationUser> User();

        public Guid Id();
    }
}
