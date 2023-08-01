using MediatR;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Constants;

namespace WorldCities.Core.IntegrationEvents.Likes.RemoveCityLike
{
    public record RemoveCityLikeEventHandler(ILikeHubClientService LikeHubClientService)
        : INotificationHandler<RemoveCityLikeEvent>
    {
        public async Task Handle(
            RemoveCityLikeEvent notification,
            CancellationToken cancellationToken
        )
        {
            await LikeHubClientService.DecreaseCityLikes(notification.CityId, cancellationToken);
        }
    }
}
