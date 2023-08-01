using FluentValidation;

namespace WorldCities.Core.Queries.Likes.IsAlreadyLiked
{
    public class IsAlreadyLikedQueryValidator : AbstractValidator<IsAlreadyLikedQuery>
    {
        public IsAlreadyLikedQueryValidator()
        {
            RuleFor(x => x.CityId).NotEmpty();
        }
    }
}
