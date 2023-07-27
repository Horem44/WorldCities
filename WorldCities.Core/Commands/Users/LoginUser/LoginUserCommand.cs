using MediatR;
using WorldCities.Core.Commands.Users.Models;

namespace WorldCities.Core.Commands.Users.LoginUser
{
    public record LoginUserCommand(string Email, string Password) : IRequest<UserDto>;
}
