using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCities.Core.Domain.Entities
{
    [Table("CitiesImages")]
    public class CityImage
    {
        [Key]
        public Guid Guid { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] FileData { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityGuid { get; set; }

        public virtual City City { get; set; }

    }
}
