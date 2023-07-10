using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.DTO.Cities.Responses
{
    public class CityResponse
    {
        public Guid CityGuid { get; set; }
        public string CityName { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }

    public static class CityExtensions
    {
        public static CityResponse ToCityResponse(this City city)
        {
            return new CityResponse() { CityGuid = city.Guid, CityName = city.Name, Lat = city.Lat, Lon = city.Lon };
        }
    }
}
