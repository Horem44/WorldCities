using MediatR;
using Microsoft.AspNetCore.Http;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public record RemoveLikeCommandHandler(ILikeRepository LikeRepository)
        : IRequestHandler<RemoveLikeCommand, Guid>
    {
        public async Task<Guid> Handle(
            RemoveLikeCommand request,
            CancellationToken cancellationToken
        )
        {
            Like? likeToDelete = await LikeRepository.GetByUserCityGuid(
                request.userId,
                request.cityId,
                cancellationToken
            );

            if (likeToDelete == null)
            {
                throw new BadHttpRequestException("Like not found", 404);
            }

            await LikeRepository.Delete(likeToDelete, cancellationToken);

            return likeToDelete.Guid;
        }
    }
}
