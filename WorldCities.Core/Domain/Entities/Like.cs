using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldCities.Core.Identity;

namespace WorldCities.Core.Domain.Entities
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        [Required]
        public Guid Guid { get; set; }

        [ForeignKey(nameof(City))]
        public Guid CityId {  get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }

        public virtual City City { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
