using AutoMapper;
using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities.Cities;

namespace WorldCities.Core.Queries.Cities.GetLikedCities
{
    public record GetUserCitiesQueryHandler(ICityRepository CityRepository, IMapper Mapper)
        : IRequestHandler<GetLikedCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetLikedCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            List<City>? likedCities = await CityRepository.GetWhere(
                c => c.Likes.Any(l => l.UserGuid == request.UserId),
                cancellationToken
            );

            return likedCities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
