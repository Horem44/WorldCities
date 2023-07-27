using MediatR;
using WorldCities.Core.Commands.Users.Models;

namespace WorldCities.Core.Commands.Users.AuthorizeUser
{
    public record AuthorizeUserCommand(Guid UserId) : IRequest<UserDto>;
}
