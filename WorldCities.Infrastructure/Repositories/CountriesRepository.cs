using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class CountriesRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountriesRepository(ApplicationDbContext db)
            : base(db) { }

        public IQueryable<Country> GetByName(string name)
        {
            return Get(c => c.Name == name);
        }
    }
}
