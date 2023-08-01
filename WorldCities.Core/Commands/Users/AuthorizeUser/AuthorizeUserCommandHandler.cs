using MediatR;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Commands.Users.Models;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Users.AuthorizeUser
{
    public record AuthorizeUserCommandHandler(
        IUserAccessor UserAccessor,
        SignInManager<ApplicationUser> SignInManager,
        IJwtService JwtService
    ) : IRequestHandler<AuthorizeUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            AuthorizeUserCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserAccessor.User();

            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await SignInManager.SignInAsync(user, isPersistent: false);

            return JwtService.CreateJwtToken(user);
        }
    }
}
