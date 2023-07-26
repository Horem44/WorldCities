using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WorldCities.Domain.Identity;

namespace WorldCities.Domain.Entities
{
    [Table("Cities")]
    public class City : IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(32)")]
        [Index(nameof(Name))]
        public string Name { get; set; } = string.Empty;

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lat))]
        public decimal Lat { get; set; }

        [Column(TypeName = "decimal(7,4)")]
        [Index(nameof(Lon))]
        public decimal Lon { get; set; }

        [ForeignKey(nameof(Country))]
        public Guid CountryId { get; set; }

        [ForeignKey(nameof(CityImage))]
        public Guid? CityImageId { get; set; }

        public virtual Country Country { get; set; } = new Country();

        public virtual CityImage CityImage { get; set; } = new CityImage();

        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();

        [ForeignKey(nameof(ApplicationUser))]
        public virtual Guid? UserId { get; set; }

        [NotMapped]
        public int LikesCount => Likes?.Count ?? 0;
    }
}
