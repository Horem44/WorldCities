using MediatR;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCountries
{
    public record UpdateUserCountriesEvent(Country Country) : INotification;
}
