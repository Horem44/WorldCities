using MediatR;
using WorldCities.Core.Queries.CityImages.Models;

namespace WorldCities.Core.Queries.CityImages.GetCityImageById
{
    public record GetCityImageByIdQuery(Guid imageId) : IRequest<CityImageDto>;
}
