using MediatR;
using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public record AddCityCommand(
        string Name,
        decimal Lat,
        decimal Lon,
        string CountryName,
        IFormFile File,
        Guid UserId
    ) : IRequest<Guid>;
}
