using AutoMapper;
using MediatR;
using System.Data.Entity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Cities.GetLikedCities
{
    public record GetLikedCitiesQueryHandler(ICityRepository CityRepository, IMapper Mapper)
        : IRequestHandler<GetLikedCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetLikedCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            List<City>? likedCities = await CityRepository
                .Get(c => c.Likes.Any(l => l.UserGuid == request.UserId))
                .ToListAsync(cancellationToken);

            return likedCities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
