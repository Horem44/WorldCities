using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Commands.Users.Models;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Users.RegisterUser
{
    public record RegisterUserCommandHandler(
        IUserRepository UserRepository,
        IMapper Mapper,
        IJwtService JwtService,
        SignInManager<ApplicationUser> SignInManager
    ) : IRequestHandler<RegisterUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken
        )
        {
            ApplicationUser user = Mapper.Map<ApplicationUser>(request);

            IdentityResult identityResult = await UserRepository.Create(user, request.Password);

            if (identityResult.Succeeded)
            {
                await SignInManager.SignInAsync(user, isPersistent: false);

                return JwtService.CreateJwtToken(user);
            }

            throw new BadRequestException(
                string.Join(" | ", identityResult.Errors.Select(e => e.Description))
            );
        }
    }
}
