using MediatR;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public record GetUserCountriesQuery(Guid UserId) : IRequest<List<CountryDto>>;
}
