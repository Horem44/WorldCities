using MediatR;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public record RemoveLikeCommandHandler(ILikeRepository LikeRepository)
        : IRequestHandler<RemoveLikeCommand, Unit>
    {
        public async Task<Unit> Handle(
            RemoveLikeCommand request,
            CancellationToken cancellationToken
        )
        {
            Like? likeToDelete = await LikeRepository
                .GetByUserCityGuid(request.userId, request.cityId)
                .FirstOrDefaultAsync(cancellationToken);

            if (likeToDelete == null)
            {
                throw new BadHttpRequestException("Like not found", 404);
            }

            await LikeRepository.Delete(likeToDelete, cancellationToken);

            return Unit.Value;
        }
    }
}
