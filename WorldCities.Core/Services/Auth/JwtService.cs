using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.DTO.Auth;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.Auth;

namespace WorldCities.Core.Services.Auth
{
    public class JwtService : IJwtService
    {
        private IConfiguration _configuration;

        public JwtService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public LoginResponse CreateJwtToken(ApplicationUser user)
        {
            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.PersonName)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey
                (
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]) 
                );

            SigningCredentials signingCredentials = new SigningCredentials
                (
                    securityKey,
                    SecurityAlgorithms.HmacSha256
                );

            JwtSecurityToken tokenGenerator = new JwtSecurityToken
                (
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string jwtToken = jwtSecurityTokenHandler.WriteToken(tokenGenerator);

            return new LoginResponse()
            { 
                Token = jwtToken,
                Email = user.Email,
                PersonName = user.PersonName,
                ExpirationTime = expiration,
            };
        }
    }
}
