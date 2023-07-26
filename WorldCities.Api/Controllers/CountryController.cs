using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Queries.Countries.GetUserCountries;
using WorldCities.Infrastructure.ModelBinders;

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
        public async Task<IActionResult> GetUserCountries(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userId
        )
        {
            List<CountryDto> userCountries = await _mediator.Send(
                new GetUserCountriesQuery(userId)
            );

            return new JsonResult(userCountries);
        }
    }
}
