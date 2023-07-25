using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Likes;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext db)
            : base(db) { }

        public async Task<Like?> GetByUserCityGuid(
            Guid userGuid,
            Guid cityGuid,
            CancellationToken cancellationToken
        )
        {
            List<Like>? likes = await GetWhere(
                l => l.UserGuid == userGuid && l.CityGuid == cityGuid,
                cancellationToken
            );

            if (likes == null || likes.Count == 0)
            {
                return null;
            }

            return likes.First();
        }
    }
}
