using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.DomainEvents.Cities.AddCityImageForCreatedCity
{
    public record AddCityImageForCreatedCityEvent(IFormFile Image, Guid CityId) : INotification;
}
