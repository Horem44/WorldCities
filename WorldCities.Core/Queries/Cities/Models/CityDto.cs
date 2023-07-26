namespace WorldCities.Core.Queries.Cities.Models
{
    public class CityDto
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string? CountryName { get; set; }
        public Guid? CityImageId { get; set; }
        public int LikesCount { get; set; }
    }
}
