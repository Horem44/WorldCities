using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.DTO.Cities
{
    public class CityResponse
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public Guid CountryGuid { get; set; }
        public string CountryName { get; set; }
        public Guid? CityImageGuid { get; set; }
        public int LikesCount { get; set; }
    }

    public static class CityExtensions
    {
        public static CityResponse ToCityResponse(this City city)
        {
            return new CityResponse()
            {
                Guid = city.Guid,
                Name = city.Name,
                Lat = city.Lat,
                Lon = city.Lon,
                CountryGuid = city.Country.Guid,
                CountryName = city.Country.Name,
                CityImageGuid = city.CityImageGuid,
                LikesCount = city.LikesCount
            };
        }
    }
}
