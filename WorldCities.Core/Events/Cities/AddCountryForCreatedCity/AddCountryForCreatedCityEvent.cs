using MediatR;

namespace WorldCities.Core.Events.Cities.AddCountryForCreatedCity
{
    public record AddCountryForCreatedCityEvent(string CountryName, Guid UserId) : INotification;
}
