using FluentValidation;

namespace WorldCities.Core.Queries.Cities.GetCountryCities
{
    public class GetCountryCitiesValidator : AbstractValidator<GetCountryCitiesQuery>
    {
        public GetCountryCitiesValidator()
        {
            RuleFor(x => x.CountryId).NotEmpty();
        }
    }
}
