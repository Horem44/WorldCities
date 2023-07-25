using Microsoft.AspNetCore.Identity;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Entities.Countries;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PersonName { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
