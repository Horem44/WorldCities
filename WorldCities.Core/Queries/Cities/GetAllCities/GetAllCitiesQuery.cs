using MediatR;
using WorldCities.Core.Queries.Cities.Models;

namespace WorldCities.Core.Queries.Cities.GetAllCities
{
    public record GetAllCitiesQuery() : IRequest<List<CityDto>>;
}
