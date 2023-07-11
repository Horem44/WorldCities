using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.DTO.Cities.Requests;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICitiesGetterService _cityGetterService;
        private readonly ICitiesAdderService _cityAdderService;

        public CityController(ICitiesGetterService cityGetterService, ICitiesAdderService cityAdderService)
        {
            _cityGetterService = cityGetterService;
            _cityAdderService = cityAdderService;
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
    }
}
