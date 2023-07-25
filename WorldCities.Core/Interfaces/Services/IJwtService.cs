using WorldCities.Core.DTO.Auth;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Interfaces.Services
{
    public interface IJwtService
    {
        public AuthResponse CreateJwtToken(ApplicationUser user);
    }
}
