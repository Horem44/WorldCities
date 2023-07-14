using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.Identity;

namespace WorldCities.Core.DTO.User
{
    public class UserResponse
    {
        public Guid Guid { get; set; }
        public string PersonName { get; set; }
    }

    public static class ApplicationUserExtensions
    {
        public static UserResponse ToUserResponse(this ApplicationUser user)
        {
            return new UserResponse()
            {
                Guid = user.Id,
                PersonName = user.PersonName,
            };
        }
    }
}
