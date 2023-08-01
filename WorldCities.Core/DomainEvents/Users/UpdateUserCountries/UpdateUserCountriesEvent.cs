using MediatR;

namespace WorldCities.Core.DomainEvents.Users.UpdateUserCountries
{
    public record UpdateUserCountriesEvent(Guid CountryId) : INotification;
}
