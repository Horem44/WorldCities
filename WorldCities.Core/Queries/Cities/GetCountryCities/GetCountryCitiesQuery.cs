using MediatR;
using WorldCities.Core.Queries.Cities.Models;

namespace WorldCities.Core.Queries.Cities.GetCountryCities
{
    public record GetCountryCitiesQuery(Guid CountryId) : IRequest<List<CityDto>>;
}
