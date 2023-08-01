using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Cities.GetUserCities
{
    public record GetUserCitiesQueryHandler(
        ICityRepository CityRepository,
        IUserAccessor UserAccessor,
        IMapper Mapper
    ) : IRequestHandler<GetUserCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetUserCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser user = await this.UserAccessor.User();

            List<City> cities = await CityRepository
                .Get(c => c.UserId == user.Id)
                .Include(c => c.Country)
                .Include(c => c.Likes)
                .ToListAsync(cancellationToken);

            return cities.Select(Mapper.Map<CityDto>).ToList();
        }
    }
}
