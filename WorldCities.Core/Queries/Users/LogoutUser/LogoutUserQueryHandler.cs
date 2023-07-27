using MediatR;
using Microsoft.AspNetCore.Identity;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Queries.Users.LogoutUser
{
    public record LogoutUserQueryHandler(SignInManager<ApplicationUser> SignInManager)
        : IRequestHandler<LogoutUserQuery, Unit>
    {
        public async Task<Unit> Handle(LogoutUserQuery request, CancellationToken cancellationToken)
        {
            await SignInManager.SignOutAsync();
            return Unit.Value;
        }
    }
}
