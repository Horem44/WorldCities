using MediatR;

namespace WorldCities.Core.IntegrationEvents.Likes.AddLike
{
    public record AddCityLikeEvent(Guid CityId) : INotification;
}
