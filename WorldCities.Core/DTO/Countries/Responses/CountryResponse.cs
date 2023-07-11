using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.DTO.Countries.Responses
{
    public class CountryResponse
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse(this Country country)
        {
            return new CountryResponse() { Guid = country.Guid, Name = country.Name };
        }
    }
}
