using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Likes.IsAlreadyLiked
{
    public record IsAlreadyLikedQueryHandler(
        ILikeRepository LikeRepository,
        IUserAccessor UserAccessor
    ) : IRequestHandler<IsAlreadyLikedQuery, bool>
    {
        public async Task<bool> Handle(
            IsAlreadyLikedQuery request,
            CancellationToken cancellationToken
        )
        {
            Like? existingLike = await LikeRepository
                .GetByUserCityGuid(UserAccessor.Id(), request.CityId)
                .FirstOrDefaultAsync(cancellationToken);

            return existingLike == null ? false : true;
        }
    }
}
