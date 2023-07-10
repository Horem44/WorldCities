using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;

namespace WorldCities.Core.Domain.Entities
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [Index(nameof(Name))]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lat))]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lon))]
        public decimal Lon { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryGuid { get; set; }
    }
}
