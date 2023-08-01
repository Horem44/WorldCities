using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCities.Domain.Identity;

namespace WorldCities.Domain.Entities
{
    [Table("Countries")]
    public class Country : IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Index(nameof(Name))]
        public string Name { get; set; } = null!;

        public ICollection<City> Cities { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        [NotMapped]
        public int CitiesCount => Cities?.Count ?? 0;
    }
}
