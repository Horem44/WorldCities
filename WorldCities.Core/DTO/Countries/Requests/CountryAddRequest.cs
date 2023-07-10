using System.ComponentModel.DataAnnotations;

namespace WorldCities.Core.DTO.Countries.Requests
{
    public class CountryAddRequest
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ISO2 { get; set; }

        [Required]
        public string ISO3 { get; set; }
    }
}
