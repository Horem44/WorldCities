using MediatR;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCities
{
    public record UpdateUserCitiesEvent(City City) : INotification;
}
