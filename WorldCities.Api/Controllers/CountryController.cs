using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Commands.Countries.AddCountry;
using WorldCities.Core.Queries.Countries.GetUserCountries;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUserCountries()
        {
            List<CountryDto> userCountries = await _mediator.Send(new GetUserCountriesQuery());

            return new JsonResult(userCountries);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCountry(AddCountryCommand command)
        {
            Guid countryId = await _mediator.Send(command);

            return Ok(countryId);
        }
    }
}
