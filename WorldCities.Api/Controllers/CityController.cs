using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Commands.Cities.AddCity;
using WorldCities.Core.Queries.Cities.GetAllCities;
using WorldCities.Core.Queries.Cities.GetCountryCities;
using WorldCities.Core.Queries.Cities.GetLikedCities;
using WorldCities.Core.Queries.Cities.GetUserCities;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Core.Queries.CityImages.GetCityImageById;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetUserCities(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid,
            CancellationToken cancellationToken
        )
        {
            List<CityDto> userCities = await _mediator.Send(
                new GetUserCitiesQuery(userGuid),
                cancellationToken
            );

            return new JsonResult(userCities);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllCities(CancellationToken cancellationToken)
        {
            List<CityDto> allCities = await _mediator.Send(
                new GetAllCitiesQuery(),
                cancellationToken
            );

            return new JsonResult(allCities);
        }

        [HttpGet]
        [Route("liked")]
        public async Task<IActionResult> GetLikedCities(
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userId,
            CancellationToken cancellationToken
        )
        {
            List<CityDto>? city = await _mediator.Send(
                new GetLikedCitiesQuery(userId),
                cancellationToken
            );

            return new JsonResult(city);
        }

        [HttpGet]
        [Authorize]
        [Route("{countryId:guid}")]
        public async Task<IActionResult> GetCountryCities(
            [FromRoute] Guid countryId,
            CancellationToken cancellationToken
        )
        {
            List<CityDto> countryCities = await _mediator.Send(
                new GetCountryCitiesQuery(countryId),
                cancellationToken
            );

            return new JsonResult(countryCities);
        }

        [HttpGet]
        [Route("image/{id:guid}")]
        public async Task<IActionResult> GetCityImage(
            [FromRoute] Guid id,
            CancellationToken cancellationToken
        )
        {
            CityImageDto cityImageDto = await _mediator.Send(
                new GetCityImageByIdQuery(id),
                cancellationToken
            );

            return new FileStreamResult(cityImageDto.MemoryStream, cityImageDto.ContentType);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddCity(
            [FromForm] AddCityCommand command,
            [ModelBinder(typeof(JwtUserIdModelBinder))] Guid userId,
            CancellationToken cancellationToken
        )
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}
