using Microsoft.AspNetCore.Identity;
using WorldCities.Domain.Entities;

namespace WorldCities.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PersonName { get; set; } = string.Empty;
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
    }
}
