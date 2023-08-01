using MediatR;
using WorldCities.Core.Queries.Cities.Models;

namespace WorldCities.Core.Queries.Cities.GetUserCities
{
    public record GetUserCitiesQuery() : IRequest<List<CityDto>>;
}
