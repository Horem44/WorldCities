using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityImageRepositoryContract;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CitiesImagesRepository
{
    public class CitiesImagesRepository : BaseRepository<CityImage>, ICityImageRepository
    {
        public CitiesImagesRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
