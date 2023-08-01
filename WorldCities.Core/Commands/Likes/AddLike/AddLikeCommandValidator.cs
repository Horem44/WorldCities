using FluentValidation;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public class AddLikeCommandValidator : AbstractValidator<AddLikeCommand>
    {
        public AddLikeCommandValidator()
        {
            RuleFor(x => x.CityId).NotEmpty();
        }
    }
}
