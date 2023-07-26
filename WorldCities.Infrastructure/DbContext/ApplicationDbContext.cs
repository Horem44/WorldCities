using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Identity;

namespace WorldCities.Infrastructure.ApplicationDatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext()
            : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<City> Cities => Set<City>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<CityImage> CitiesImages => Set<CityImage>();
        public DbSet<Like> Likes => Set<Like>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Like>().HasIndex(l => new { l.CityGuid, l.UserGuid }).IsUnique();
        }
    }
}
