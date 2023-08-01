using FluentValidation;
using MediatR;
using WorldCities.Core.Queries.Users.IsEmailAlreadyExists;

namespace WorldCities.Core.Commands.Users.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IMediator _mediator;

        public RegisterUserCommandValidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(x => x.Email).NotEmpty().EmailAddress().MustAsync(BeUniqueEmail);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.PersonName).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty().Equal(x => x.Password);
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            bool isEmailExists = await _mediator.Send(
                new IsEmailAlreadyExistsQuery(email),
                cancellationToken
            );

            return !isEmailExists;
        }
    }
}
