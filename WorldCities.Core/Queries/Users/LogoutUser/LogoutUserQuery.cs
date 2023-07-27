using MediatR;

namespace WorldCities.Core.Queries.Users.LogoutUser
{
    public record LogoutUserQuery() : IRequest<Unit>;
}
