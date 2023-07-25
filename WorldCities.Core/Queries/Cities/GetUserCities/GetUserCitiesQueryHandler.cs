using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Cities.GetUserCities
{
    public record GetUserCitiesQueryHandler(IUserRepository UserRepository, IMapper Mapper)
        : IRequestHandler<GetUserCitiesQuery, List<CityDto>>
    {
        public async Task<List<CityDto>> Handle(
            GetUserCitiesQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserRepository
                .GetUsers()
                .Include(u => u.Cities)
                .ThenInclude(c => c.Country)
                .Include(u => u.Cities)
                .ThenInclude(c => c.Likes)
                .Include(c => c.Likes)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            return user?.Cities != null ? user.Cities.Select(Mapper.Map<CityDto>).ToList() : new();
        }
    }
}
