namespace WorldCities.Core.Queries.CityImages.Models
{
    public class CityImageDto
    {
        public MemoryStream MemoryStream { get; set; } = new MemoryStream();
        public string ContentType { get; set; } = string.Empty;
    }
}
