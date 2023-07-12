using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.DTO.Auth;
using WorldCities.Core.Identity;

namespace WorldCities.Core.ServiceContracts.Auth
{
    public interface IJwtService
    {
        public LoginResponse CreateJwtToken(ApplicationUser user);
    }
}
