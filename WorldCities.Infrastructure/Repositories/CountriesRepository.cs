using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Entities.Countries;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class CountriesRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _db;

        public CountriesRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public async Task<Country?> GetByName(string name, CancellationToken cancellationToken)
        {
            List<Country>? matchingCountries = await GetWhere(
                c => c.Name == name,
                cancellationToken
            );

            if (matchingCountries != null && matchingCountries.Count() > 0)
            {
                return matchingCountries[0];
            }

            return null;
        }

        public async Task<List<City>> GetCountryCities(
            Guid countryGuid,
            CancellationToken cancellationToken
        )
        {
            List<City> countryCities = await _db.Countries
                .Where(c => c.Guid == countryGuid)
                .Include(c => c.Cities)
                .ThenInclude(c => c.Likes)
                .Include(c => c.Cities)
                .ThenInclude(c => c.Country)
                .SelectMany(c => c.Cities)
                .ToListAsync(cancellationToken);

            return countryCities;
        }
    }
}
