using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CountriesRepository
{
    public class CountriesRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountriesRepository(ApplicationDbContext db): base(db) { }

        public async Task<Country?> GetByName(string name)
        {
            List<Country>? matchingCountries = await getWhere(c => c.Name == name);

            if(matchingCountries != null && matchingCountries.Count() > 0)
            {
                return matchingCountries[0];
            }

            return null;
        }
    }
}
