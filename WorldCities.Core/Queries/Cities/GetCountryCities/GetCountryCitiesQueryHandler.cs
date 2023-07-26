using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Cities.GetCountryCities
{
    public record GetCountryCitiesQueryHandler(ICountryRepository CountryRepository, IMapper Mapper)
        : IRequestHandler<GetCountryCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetCountryCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            Country? country = await CountryRepository
                .Get(request.CountryId)
                .Include(c => c.Cities)
                .ThenInclude(city => city.Likes)
                .FirstOrDefaultAsync(cancellationToken);

            return country?.Cities != null
                ? country.Cities
                    .Select(city =>
                    {
                        CityDto cityDto = Mapper.Map<CityDto>(city);
                        cityDto.CountryName = country.Name;
                        return cityDto;
                    })
                    .ToList()
                : new();
        }
    }
}
