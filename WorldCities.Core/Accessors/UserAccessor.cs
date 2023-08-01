using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Accessors
{
    public record UserAccessor(IUserRepository UserRepository) : IUserAccessor
    {
        public async Task<ApplicationUser> User()
        {
            ApplicationUser? user = await UserRepository.GetCurrentUser();

            return user == null ? throw new UnauthorizedException("Unauthorized") : user;
        }

        public Guid Id()
        {
            Guid? id = UserRepository.GetCurrentUserId();

            return id == null ? throw new UnauthorizedException("Unauthorized") : (Guid)id;
        }
    }
}
