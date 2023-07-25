using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class CitiesImagesRepository : BaseRepository<CityImage>, ICityImageRepository
    {
        public CitiesImagesRepository(ApplicationDbContext db)
            : base(db) { }
    }
}
