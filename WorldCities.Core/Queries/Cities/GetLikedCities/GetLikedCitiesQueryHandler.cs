using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Cities.GetLikedCities
{
    public record GetLikedCitiesQueryHandler(
        ICityRepository CityRepository,
        IUserAccessor UserAccessor,
        IMapper Mapper
    ) : IRequestHandler<GetLikedCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetLikedCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserAccessor.User();

            List<City>? likedCities = await CityRepository
                .Get(c => c.Likes.Any(l => l.UserId == user.Id))
                .Include(c => c.Likes)
                .Include(c => c.Country)
                .ToListAsync(cancellationToken);

            return likedCities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
