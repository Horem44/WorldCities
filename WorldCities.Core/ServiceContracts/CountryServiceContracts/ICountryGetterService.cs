using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.DTO.Countries;

namespace WorldCities.Core.ServiceContracts.CountryServiceContracts
{
    public interface ICountryGetterService
    {
        Task<List<CountryResponse>> GetUserCountries(Guid userGuid);
        Task<List<CityResponse>> GetCountryCities(Guid countryId);
    }
}
