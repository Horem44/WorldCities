using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Core.Queries.Likes.IsAlreadyLiked
{
    public record IsAlreadyLikedQueryHandler(ILikeRepository LikeRepository)
        : IRequestHandler<IsAlreadyLikedQuery, bool>
    {
        public async Task<bool> Handle(
            IsAlreadyLikedQuery request,
            CancellationToken cancellationToken
        )
        {
            Like? existingLike = await LikeRepository.GetByUserCityGuid(
                request.userId,
                request.cityId,
                cancellationToken
            );

            return existingLike == null ? false : true;
        }
    }
}
