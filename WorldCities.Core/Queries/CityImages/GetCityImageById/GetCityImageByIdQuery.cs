using MediatR;

namespace WorldCities.Core.Queries.CityImages.GetCityImageById
{
    public record GetCityImageByIdQuery(Guid imageId) : IRequest<CityImageDto>;
}
