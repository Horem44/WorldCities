using WorldCities.Domain.Entities;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface ILikeRepository : IBaseRepository<Like>
    {
        IQueryable<Like> GetByUserCityGuid(Guid userGuid, Guid cityGuid);
    }
}
