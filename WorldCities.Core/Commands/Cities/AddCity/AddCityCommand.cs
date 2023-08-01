using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommand(
        string Name,
        decimal Lat,
        decimal Lon,
        IFormFile Image,
        Guid CountryId
    ) : IRequest<Unit>;
}
