using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext db)
            : base(db) { }

        public IQueryable<Like> GetByUserCityGuid(Guid userGuid, Guid cityGuid)
        {
            return Get(l => l.UserGuid == userGuid && l.CityGuid == cityGuid);
        }
    }
}
