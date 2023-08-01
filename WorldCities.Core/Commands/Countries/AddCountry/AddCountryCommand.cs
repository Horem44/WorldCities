using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WorldCities.Core.Commands.Countries.AddCountry
{
    public record AddCountryCommand(string CountryName) : IRequest<Guid>;
}
