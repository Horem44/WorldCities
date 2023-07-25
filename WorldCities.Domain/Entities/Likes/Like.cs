using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Identity;

namespace WorldCities.Domain.Entities.Likes
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityGuid { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserGuid { get; set; }

        public virtual City City { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
