using FluentValidation;

namespace WorldCities.Core.Queries.CityImages.GetCityImageById
{
    public class GetCityImageByIdQueryValidator : AbstractValidator<GetCityImageByIdQuery>
    {
        public GetCityImageByIdQueryValidator()
        {
            RuleFor(x => x.imageId).NotEmpty();
        }
    }
}
