using MediatR;
using WorldCities.Core.Commands.Users.Models;

namespace WorldCities.Core.Commands.Users.RegisterUser
{
    public record RegisterUserCommand(
        string PersonName,
        string Email,
        string Password,
        string ConfirmPassword
    ) : IRequest<UserDto>;
}
