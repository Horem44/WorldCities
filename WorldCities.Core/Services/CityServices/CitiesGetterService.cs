using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Core.Services.CityServices
{
    public class CitiesGetterService : ICitiesGetterService
    {
        private readonly ICityRepository _cityRepository;

        public CitiesGetterService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<CityResponse>?> getAllCities()
        {
            List<City>? allCities = await _cityRepository.all();

            if(allCities == null)
            {
                return null;
            }

            return allCities.Select(c => c.ToCityResponse()).ToList();
        }

        public async Task<CityResponse?> getCityByGuid(Guid? guid)
        {
            if(guid == null)
            {
                return null;
            }

            City? city = await _cityRepository.getByGuid(guid);

            if(city == null)
            {
                return null;
            }

            return city.ToCityResponse();
        }
    }
}
