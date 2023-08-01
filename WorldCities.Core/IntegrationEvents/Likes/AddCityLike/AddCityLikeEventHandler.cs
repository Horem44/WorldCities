using MediatR;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Constants;

namespace WorldCities.Core.IntegrationEvents.Likes.AddLike
{
    public record AddCityLikeEventHandler(ILikeHubClientService LikeHubClientService)
        : INotificationHandler<AddCityLikeEvent>
    {
        public async Task Handle(AddCityLikeEvent notification, CancellationToken cancellationToken)
        {
            await LikeHubClientService.IncreaseCityLikes(notification.CityId, cancellationToken);
        }
    }
}
