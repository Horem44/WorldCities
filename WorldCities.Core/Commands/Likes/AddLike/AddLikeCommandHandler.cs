using AutoMapper;
using MediatR;
using WorldCities.Core.IntegrationEvents.Likes.AddLike;
using WorldCities.Core.Interfaces.Events;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommandHandler(
        ILikeRepository LikeRepository,
        IMapper Mapper,
        IEventPublisher EventPublisher
    ) : IRequestHandler<AddLikeCommand, Unit>
    {
        public async Task<Unit> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = Mapper.Map<Like>(request);
            await LikeRepository.Add(like, cancellationToken);

            await EventPublisher.PublishAsync(
                Mapper.Map<AddCityLikeEvent>(request),
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
