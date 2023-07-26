using MediatR;

namespace WorldCities.Core.Events.Users.UpdateUserCities
{
    public record UpdateUserCitiesEvent(Guid UserId, Guid CityId) : INotification;
}
