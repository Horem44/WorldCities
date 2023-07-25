using MediatR;
using WorldCities.Core.Queries.Countries.Models;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public record GetUserCountriesQuery(Guid UserId) : IRequest<List<CountryDto>>;
}
