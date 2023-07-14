using WorldCities.Core.DTO.Cities;

namespace WorldCities.Core.ServiceContracts.CityServiceContracts
{
    public interface ICitiesAdderService
    {
        Task<CityResponse?> addCity(CityAddRequest city, string? userId);
    }
}
