using MediatR;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Users.IsEmailAlreadyExists
{
    public record IsEmailAlreadyExistsQueryHandler(IUserRepository UserRepository)
        : IRequestHandler<IsEmailAlreadyExistsQuery, bool>
    {
        public async Task<bool> Handle(
            IsEmailAlreadyExistsQuery request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserRepository.FindByEmail(request.Email);
            return user != null ? false : true;
        }
    }
}
