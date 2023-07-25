using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.Commands.CityImages.AddCityImage
{
    public record AddCityImageCommand(IFormFile image, Guid cityId) : IRequest<Guid>;
}
