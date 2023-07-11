using WorldCities.Core.DTO.Cities.Requests;
using WorldCities.Core.DTO.Cities.Responses;

namespace WorldCities.Core.ServiceContracts.CityServiceContracts    
{
    public interface ICitiesAdderService
    {
        Task<CityResponse> addCity(CityAddRequest city);
    }
}
