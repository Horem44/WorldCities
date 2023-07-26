using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.Events.Cities.CityCreated
{
    public record CityCreatedEvent(IFormFile Image, Guid CityId, string CountryName, Guid UserId)
        : INotification;
}
