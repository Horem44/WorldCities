using MediatR;

namespace WorldCities.Core.Events.Users.UpdateUserCountries
{
    public record UpdateUserCountriesEvent(Guid UserId, Guid CountryId) : INotification;
}
