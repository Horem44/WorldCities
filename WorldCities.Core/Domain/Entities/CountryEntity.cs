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
    public class Country
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [Index(nameof(Name))]
        public string Name { get; set; } = null!;

        [Index(nameof(ISO2))]
        public string ISO2 { get; set; } = null!;

        [Index(nameof(ISO3))]
        public string ISO3 { get; set; } = null!;

        public ICollection<City>? Cities { get; set; } = null!;
    }
}
