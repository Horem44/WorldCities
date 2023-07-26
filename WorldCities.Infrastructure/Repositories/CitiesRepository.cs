using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class CitiesRepository : BaseRepository<City>, ICityRepository
    {
        public CitiesRepository(ApplicationDbContext db)
            : base(db) { }
    }
}
