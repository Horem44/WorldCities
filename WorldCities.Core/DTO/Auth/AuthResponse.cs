using System;
using System.Collections.Generic;

namespace WorldCities.Core.DTO.Auth
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
