using WorldCities.Core.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CountriesRepository
{
    internal class CountriesRepository : BaseRepository<Country>
    {
        public CountriesRepository(ApplicationDbContext db): base(db) { }
    }
}
