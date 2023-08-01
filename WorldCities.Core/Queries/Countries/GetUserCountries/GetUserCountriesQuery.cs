using MediatR;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public record GetUserCountriesQuery() : IRequest<List<CountryDto>>;
}
