using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.IntegrationEvents.Likes.RemoveCityLike;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Events;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Exceptions;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public record RemoveLikeCommandHandler(
        ILikeRepository LikeRepository,
        IUserAccessor UserAccessor,
        IEventPublisher EventPublisher,
        IMapper Mapper
    ) : IRequestHandler<RemoveLikeCommand, Unit>
    {
        public async Task<Unit> Handle(
            RemoveLikeCommand request,
            CancellationToken cancellationToken
        )
        {
            Like? likeToDelete =
                await LikeRepository
                    .GetByUserCityGuid(UserAccessor.Id(), request.CityId)
                    .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException("Like not found");

            await LikeRepository.Delete(likeToDelete, cancellationToken);

            await EventPublisher.PublishAsync(
                Mapper.Map<RemoveCityLikeEvent>(request),
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
