using FluentValidation;

namespace WorldCities.Core.Commands.Countries.AddCountry
{
    public class AddCountryValidator : AbstractValidator<AddCountryCommand>
    {
        public AddCountryValidator()
        {
            RuleFor(x => x.CountryName).NotEmpty();
        }
    }
}
