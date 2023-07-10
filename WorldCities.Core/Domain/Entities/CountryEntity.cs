using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Core.Domain.Entities
{
    [Table("Countries")]
    [Index(nameof(Name))]
    [Index(nameof(ISO2))]
    [Index(nameof(ISO3))]
    public class CountryEntity
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        public string Name { get; set; } = null!;

        public string ISO2 { get; set; } = null!;

        public string ISO3 { get; set; } = null!;

        public ICollection<CityEntity>? Cities { get; set; } = null!;
    }
}
