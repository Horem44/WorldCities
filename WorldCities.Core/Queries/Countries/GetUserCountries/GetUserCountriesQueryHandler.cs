using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public record GetUserCountriesQueryHandler(IUserRepository UserRepository, IMapper Mapper)
        : IRequestHandler<GetUserCountriesQuery, List<CountryDto>>
    {
        public async Task<List<CountryDto>> Handle(
            GetUserCountriesQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserRepository
                .GetUsers()
                .Include(u => u.Countries)
                .ThenInclude(c => c.Cities)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            return user?.Countries != null
                ? user.Countries.Select(Mapper.Map<CountryDto>).ToList()
                : new();
        }
    }
}
