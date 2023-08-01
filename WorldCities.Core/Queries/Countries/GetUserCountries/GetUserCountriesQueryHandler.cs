using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public record GetUserCountriesQueryHandler(
        ICountryRepository CountryRepository,
        IUserAccessor UserAccessor,
        IMapper Mapper
    ) : IRequestHandler<GetUserCountriesQuery, List<CountryDto>>
    {
        public async Task<List<CountryDto>> Handle(
            GetUserCountriesQuery request,
            CancellationToken cancellationToken
        )
        {
            List<Country> countries = await CountryRepository
                .Get(c => c.Users.Any(u => u.Id == UserAccessor.Id()))
                .Include(c => c.Cities)
                .ToListAsync(cancellationToken);

            return countries.Select(Mapper.Map<CountryDto>).ToList();
        }
    }
}
