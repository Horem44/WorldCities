using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.DTO.Cities.Requests;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Core.Services.CityServices
{
    public class CitiesAdderService : ICitiesAdderService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public CitiesAdderService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task<CityResponse> addCity(CityAddRequest city)
        {
            City cityToAdd = city.ToCity();

            Country? existingCountry = await _countryRepository.GetByName(city.Name);

            if (existingCountry == null)
            {
                Country newCountry = await _countryRepository.add(new Country() 
                { Name = city.CountryName, Guid = Guid.NewGuid() });

                cityToAdd.CountryGuid = newCountry.Guid;
            }


            await _cityRepository.add(cityToAdd);


            return cityToAdd.ToCityResponse();
        }
    }
}
