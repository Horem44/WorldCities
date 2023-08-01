using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using WorldCities.Core.Commands.Users.Models;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Exceptions;
using WorldCities.Domain.Identity;

namespace WorldCities.Core.Commands.Users.LoginUser
{
    public record LoginUserCommandHandler(
        SignInManager<ApplicationUser> SignInManager,
        IUserRepository UserRepository,
        IJwtService JwtService,
        IMapper Mapper
    ) : IRequestHandler<LoginUserCommand, UserDto>
    {
        public async Task<UserDto> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken
        )
        {
            SignInResult signInResult = await SignInManager.PasswordSignInAsync(
                request.Email,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            ApplicationUser? user = await UserRepository.FindByEmail(request.Email);

            if (signInResult.Succeeded && user != null)
            {
                return JwtService.CreateJwtToken(user);
            }

            throw new BadRequestException("Wrong email or password");
        }
    }
}
