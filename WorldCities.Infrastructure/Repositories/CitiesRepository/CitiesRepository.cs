using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.CitiesRepository
{
    public class CitiesRepository : BaseRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;
        public CitiesRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public override async Task<List<City>?> all()
        {
            List<City>? allCities = await _db.Cities
                .Include(c => c.Country)
                .Include(c => c.Likes)
                .ToListAsync();

            return allCities;
        }

        public override async Task<City?> getByGuid(Guid? guid)
        {
            City? city = await _db.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Guid == guid);

            return city;
        }
    }
}
