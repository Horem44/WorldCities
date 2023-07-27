using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.Events.Cities.AddCityImageForCreatedCity
{
    public record AddCityImageForCreatedCityEvent(IFormFile Image, Guid CityId) : INotification;
}
