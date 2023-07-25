using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        Task<Like?> GetByUserCityGuid(
            Guid userGuid,
            Guid cityGuid,
            CancellationToken cancellationToken
        );
    }
}
