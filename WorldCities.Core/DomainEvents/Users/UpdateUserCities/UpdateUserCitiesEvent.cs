using MediatR;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCities
{
    public record UpdateUserCitiesEvent(Guid CityId) : INotification;
}
