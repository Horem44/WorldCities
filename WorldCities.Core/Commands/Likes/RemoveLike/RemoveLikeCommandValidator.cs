using FluentValidation;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    internal class RemoveLikeCommandValidator : AbstractValidator<RemoveLikeCommand>
    {
        public RemoveLikeCommandValidator()
        {
            RuleFor(x => x.CityId).NotEmpty();
        }
    }
}
