using MediatR;

namespace WorldCities.Core.IntegrationEvents.Likes.RemoveCityLike
{
    public record RemoveCityLikeEvent(Guid CityId) : INotification;
}
