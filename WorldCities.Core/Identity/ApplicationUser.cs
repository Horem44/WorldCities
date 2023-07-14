using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PersonName { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

    }
}
