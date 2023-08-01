using FluentValidation;

namespace WorldCities.Core.Queries.Users.IsEmailAlreadyExists
{
    public class IsEmailAlreadyExistsValidator : AbstractValidator<IsEmailAlreadyExistsQuery>
    {
        public IsEmailAlreadyExistsValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
        }
    }
}
