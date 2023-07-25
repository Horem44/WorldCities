using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorldCities.Domain.Identity;
using WorldCities.Domain.Entities.Countries;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Domain.Entities.Cities
{
    [Table("Cities")]
    public class City
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [Column(TypeName = "varchar(32)")]
        [Index(nameof(Name))]
        public string Name { get; set; } = null!;

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lat))]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lon))]
        public decimal Lon { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CityImage))]
        public Guid? CityImageGuid { get; set; }

        public virtual Country Country { get; set; }

        public virtual CityImage CityImage { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        [NotMapped]
        public int LikesCount => Likes?.Count ?? 0;
    }
}
