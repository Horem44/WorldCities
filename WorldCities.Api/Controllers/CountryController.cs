using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.DTO.Countries;
using WorldCities.Core.ServiceContracts.CountryServiceContracts;
using WorldCities.Infrastructure.ModelBinders;

namespace WorldCities.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryGetterService _countryGetterService;

        public CountryController(ICountryGetterService countryGetterService)
        {
            _countryGetterService = countryGetterService;
        }

        [HttpGet]
        [Authorize]
        [Route("")]
        public async Task<IActionResult> getUserCountries([ModelBinder(typeof(JwtUserIdModelBinder))] Guid userGuid)
        {
            List<CountryResponse>? userCountries = await _countryGetterService.GetUserCountries(userGuid);
            return new JsonResult(userCountries);
        }

        [HttpGet]
        [Authorize]
        [Route("{countryGuid:guid}")]
        public async Task<IActionResult> getCountryCities([FromRoute] Guid countryGuid)
        {
            List<CityResponse>? countryCities = await _countryGetterService.GetCountryCities(countryGuid);
            return new JsonResult(countryCities);
        }
    }
}
