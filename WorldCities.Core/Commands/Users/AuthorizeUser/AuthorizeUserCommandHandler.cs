using MediatR;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Commands.Users.Models;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Users.AuthorizeUser
{
    public record AuthorizeUserCommandHandler(
        IUserRepository UserRepository,
        SignInManager<ApplicationUser> SignInManager,
        IJwtService JwtService
    ) : IRequestHandler<AuthorizeUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            AuthorizeUserCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser? user = await UserRepository.FindById(request.UserId.ToString());

            if (user == null)
            {
                throw new Exception();
            }

            await SignInManager.SignInAsync(user, isPersistent: false);

            return JwtService.CreateJwtToken(user);
        }
    }
}
