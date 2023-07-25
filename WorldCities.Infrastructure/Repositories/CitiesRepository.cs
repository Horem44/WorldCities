using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Cities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class CitiesRepository : BaseRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CitiesRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public override async Task<List<City>?> All(CancellationToken cancellationToken)
        {
            List<City>? allCities = await _db.Cities
                .Include(c => c.Country)
                .Include(c => c.Likes)
                .ToListAsync(cancellationToken);

            return allCities;
        }

        public override async Task<City?> GetByGuid(Guid guid, CancellationToken cancellationToken)
        {
            City? city = await _db.Cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Guid == guid, cancellationToken);

            return city;
        }

        public override async Task<List<City>> GetWhere(
            Expression<Func<City, bool>> predicate,
            CancellationToken cancellationToken
        )
        {
            List<City> cities = await _db.Cities
                .Include(c => c.Country)
                .Include(c => c.Likes)
                .Where(predicate)
                .ToListAsync(cancellationToken);

            return cities;
        }
    }
}
