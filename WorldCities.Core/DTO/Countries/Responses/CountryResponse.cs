using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.DTO.Countries.Responses
{
    public class CountryResponse
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string ISO2 { get; set; }

        public string ISO3 { get; set; }
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { Guid = country.Guid, Name = country.Name, ISO2 = country.ISO2, ISO3 = country.ISO3 };
        }
    }
}
