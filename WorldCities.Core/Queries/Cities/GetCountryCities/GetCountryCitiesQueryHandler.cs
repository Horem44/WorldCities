using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities.Cities;

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
            List<City> countryCities = await CountryRepository.GetCountryCities(
                request.CountryId,
                cancellationToken
            );
            return countryCities.Select(c => Mapper.Map<CityDto>(c)).ToList();
        }
    }
}
