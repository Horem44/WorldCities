using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities.Requests;
using WorldCities.Core.DTO.Cities.Responses;
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
        private readonly ICityImageAdderService _cityImageAdderService;

        public CityController
            (
                ICitiesGetterService cityGetterService,
                ICitiesAdderService cityAdderService,
                ICityImageGetterService cityImageGetterService,
                ICityImageAdderService cityImageAdderService
            )
        {
            _cityGetterService = cityGetterService;
            _cityAdderService = cityAdderService;
            _cityImageGetterService = cityImageGetterService;
            _cityImageAdderService = cityImageAdderService;
        }

        [HttpGet]
        [Route("")]
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
        [Route("")]
        public async Task<IActionResult> addCity(CityAddRequest cityAddRequest)
        {
            CityResponse? city = await _cityAdderService.addCity(cityAddRequest);
            return new JsonResult(city);
        }

        [HttpGet]
        [Route("image/{guid:guid}")]
        public async Task<IActionResult> GetCityImage([FromRoute] Guid guid)
        {
            CityImage? image = await _cityImageGetterService.getFileByGuid(guid);
            var imageStream = new MemoryStream(image.FileData);
            return File(imageStream, image.ContentType);
        }

        [HttpPost]
        [Route("image")]
        public async Task<IActionResult> UploadCityImage([FromForm] IFormFile image)
        {
            Guid imageGuid = await _cityImageAdderService.UploadCityImage(image);
            return new JsonResult(imageGuid);
        }
    }
}
