using MediatR;
using WorldCities.Core.Queries.Cities.Models;

namespace WorldCities.Core.Queries.Cities.GetLikedCities
{
    public record GetLikedCitiesQuery() : IRequest<List<CityDto>>;
}
