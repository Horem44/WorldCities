using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Core.DTO.Auth
{
    public class RegisterDto
    {
        [Required]
        public string PersonName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailAlreadyExists", controller: "Account")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
