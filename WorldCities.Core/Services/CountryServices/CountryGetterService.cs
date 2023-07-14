using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.DTO.Countries;
using WorldCities.Core.ServiceContracts.CountryServiceContracts;

namespace WorldCities.Core.Services.CountryServices
{
    public class CountryGetterService : ICountryGetterService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryGetterService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

    }
}
