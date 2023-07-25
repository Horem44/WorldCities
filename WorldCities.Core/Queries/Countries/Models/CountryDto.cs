namespace WorldCities.Core.Queries.Countries.Models
{
    public class CountryDto
    {
        public Guid Guid { get; set; }

        public string? Name { get; set; }

        public int CitiesCount { get; set; }
    }
}
