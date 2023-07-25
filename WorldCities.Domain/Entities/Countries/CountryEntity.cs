using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Identity;

namespace WorldCities.Domain.Entities.Countries
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [Index(nameof(Name))]
        public string Name { get; set; } = null!;

        public ICollection<City>? Cities { get; set; } = null!;

        public virtual ICollection<ApplicationUser> Users { get; set; }

        [NotMapped]
        public int CitiesCount => Cities?.Count ?? 0;
    }
}
