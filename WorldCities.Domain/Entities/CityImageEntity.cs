using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCities.Domain.Entities
{
    [Table("CitiesImages")]
    public class CityImage : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] FileData { get; set; } = new byte[0];

        [ForeignKey(nameof(City))]
        public Guid CityId { get; set; }

        public virtual City City { get; set; } = new City();
    }
}
