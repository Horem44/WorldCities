using FluentValidation;
using MediatR;
using WorldCities.Core.Queries.Users.IsEmailAlreadyExists;

namespace WorldCities.Core.Commands.Users.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.PersonName).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
        }
    }
}
