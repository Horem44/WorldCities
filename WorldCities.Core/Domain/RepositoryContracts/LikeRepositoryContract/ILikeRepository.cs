using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.Domain.RepositoryContracts.LikeRepositoryContract
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        Task<Like> GetByUserCityGuid(Guid userGuid, Guid cityGuid);
    }
}
