using FluentValidation;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public class AddCityCommandValidator : AbstractValidator<AddCityCommand>
    {
        public AddCityCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Lat).NotEmpty();
            RuleFor(x => x.Lon).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
