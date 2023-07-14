using Microsoft.Identity.Client;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.LikeRepositoryContract;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

namespace WorldCities.Infrastructure.Repositories.LikeRepository
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(ApplicationDbContext db) : base(db)
        {
           
        }

        public async Task<Like> GetByUserCityGuid(Guid userGuid, Guid cityGuid)
        {
            List<Like>? likes = await getWhere(l => l.UserGuid == userGuid && l.CityGuid == cityGuid);
            return likes.First();
         }
    }
}
