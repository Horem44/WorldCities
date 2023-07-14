using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WorldCities.Core.DTO.Like
{
    public class LikeDto
    {
        [Required]
        public Guid CityGuid { get; set; }
    }
}
