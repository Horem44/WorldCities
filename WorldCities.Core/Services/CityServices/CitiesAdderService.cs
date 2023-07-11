using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.DTO.Cities.Requests;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Core.Services.CityServices
{
    public class CitiesAdderService : ICitiesAdderService
    {
        private readonly ICityRepository _cityRepository;

        public CitiesAdderService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<CityResponse> addCity(CityAddRequest city)
        {
            City cityToAdd = city.ToCity();
            await _cityRepository.add(cityToAdd);

            return cityToAdd.ToCityResponse();
        }
    }
}
