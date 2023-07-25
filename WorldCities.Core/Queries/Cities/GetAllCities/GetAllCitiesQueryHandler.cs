using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities.Cities;

namespace WorldCities.Core.Queries.Cities.GetAllCities
{
    public record GetAllCitiesQueryHandler(ICityRepository CityRepository, IMapper Mapper)
        : IRequestHandler<GetAllCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetAllCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            List<City>? allCities = await CityRepository.All(cancellationToken);

            if (allCities == null)
            {
                throw new Exception();
            }

            return allCities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
