using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICitiesGetterService _cityGetterService;
        private readonly ICitiesAdderService _cityAdderService;

        private readonly ICityImageGetterService _cityImageGetterService;

        public CityController
            (
                ICitiesGetterService cityGetterService,
                ICitiesAdderService cityAdderService,
                ICityImageGetterService cityImageGetterService
            )
        {
            _cityGetterService = cityGetterService;
            _cityAdderService = cityAdderService;
            _cityImageGetterService = cityImageGetterService;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> getUserCities()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<CityResponse>? userCities = await _cityGetterService.GetUserCities(userId);
            return new JsonResult(userCities);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> getAllCities()
        {
            List<CityResponse>? allCities = await _cityGetterService.getAllCities();
            return new JsonResult(allCities);
        }

        [HttpGet]
        [Route("{guid:guid}")]
        public async Task<IActionResult> getCityByGuid([FromRoute] Guid guid)
        {
            CityResponse? city = await _cityGetterService.getCityByGuid(guid);
            return new JsonResult(city);
        }

        [HttpPost]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> addCity([FromForm] CityAddRequest cityAddRequest)
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CityResponse? city = await _cityAdderService.addCity(cityAddRequest, userId);
            return new JsonResult(city);
        }

        [HttpGet]
        [Route("image/{guid:guid}")]
        public async Task<IActionResult> GetCityImage([FromRoute] Guid guid)
        {
            CityImage? image = await _cityImageGetterService.getFileByGuid(guid);
            var imageStream = new MemoryStream(image.FileData);
            return new FileStreamResult(imageStream, image.ContentType);
        }
    }
}
