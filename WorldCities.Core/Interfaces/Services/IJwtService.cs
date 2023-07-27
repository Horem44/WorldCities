using WorldCities.Core.Commands.Users.Models;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Interfaces.Services
{
    public interface IJwtService
    {
        public UserDto CreateJwtToken(ApplicationUser user);
    }
}
