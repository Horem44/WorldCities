using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.DTO.Cities
{
    public class CityAddRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Lon { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public IFormFile File { get; set; }

        public City ToCity()
        {
            return new City { Name = Name, Lat = Lat, Lon = Lon };
        }
    }
}
