
using WorldCities.Core.DTO.Like;

namespace WorldCities.Core.ServiceContracts.Like
{
    public interface ILikeService
    {
        Task<LikeResponse> AddLike(Guid userGuid, Guid cityGuid);
        Task RemoveLike(Guid userGuid, Guid cityGuid);

        Task<bool> IsAlreadyExists(Guid userGuid, Guid cityGuid);
    }
}
