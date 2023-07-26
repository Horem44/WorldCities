using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;

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
            List<City>? allCities = await CityRepository
                .Get()
                .Include(c => c.Country)
                .Include(c => c.Likes)
                .ToListAsync(cancellationToken);

            if (allCities == null)
            {
                throw new Exception();
            }

            return allCities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
