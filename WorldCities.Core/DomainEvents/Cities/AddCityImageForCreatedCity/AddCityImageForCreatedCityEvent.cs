using MediatR;
using Microsoft.AspNetCore.Http;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.DomainEvents.Cities.AddCityImageForCreatedCity
{
    public record AddCityImageForCreatedCityEvent(IFormFile Image, City City) : INotification;
}
