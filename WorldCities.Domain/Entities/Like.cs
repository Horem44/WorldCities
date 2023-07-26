using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCities.Domain.Identity;

namespace WorldCities.Domain.Entities
{
    [Table("Likes")]
    public class Like : IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityGuid { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserGuid { get; set; }
        public virtual City City { get; set; } = new City();
        public virtual ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
    }
}
