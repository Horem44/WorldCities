using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CitiesRepository
{
    public class CitiesRepository : BaseRepository<City>, ICityRepository
    {
        public CitiesRepository(ApplicationDbContext db) : base(db) { }
    }
}
