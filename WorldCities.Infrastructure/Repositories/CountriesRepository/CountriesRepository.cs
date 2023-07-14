using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.DTO.Cities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CountriesRepository
{
    public class CountriesRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _db;
        public CountriesRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }

        public async Task<Country?> GetByName(string name)
        {
            List<Country>? matchingCountries = await getWhere(c => c.Name == name);

            if(matchingCountries != null && matchingCountries.Count() > 0)
            {
                return matchingCountries[0];
            }

            return null;
        }


        public async Task<List<City>> GetCountryCities(Guid countryGuid)
        {
            List<City> countryCities = await _db.Countries
                .Where(c => c.Guid == countryGuid)
                .Include(c => c.Cities)
                .ThenInclude(c => c.Likes)
                .Include(c => c.Cities)
                .ThenInclude(c => c.Country)
                .SelectMany(c => c.Cities)
                .ToListAsync();
            
            return countryCities;
        }
    }
}
