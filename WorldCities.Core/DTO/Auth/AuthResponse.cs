using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.Identity;

namespace WorldCities.Core.DTO.Auth
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
