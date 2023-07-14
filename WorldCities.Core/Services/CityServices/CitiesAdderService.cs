using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Core.Services.CityServices
{
    public class CitiesAdderService : ICitiesAdderService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityImageAdderService _cityImageAdderService;
        private readonly UserManager<ApplicationUser> _userManager;
        public CitiesAdderService
            (
            ICityRepository cityRepository, 
            ICountryRepository countryRepository, 
            ICityImageAdderService cityImageAdderService,
            UserManager<ApplicationUser> userManager
            )
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _cityImageAdderService = cityImageAdderService;
            _userManager = userManager;
        }

        public async Task<CityResponse?> addCity(CityAddRequest city, Guid? userId)
        {
            if(userId == null)
            {
                return null;
            }

            City cityToAdd = city.ToCity();

            Country? existingCountry = await _countryRepository.GetByName(city.Name);

            if (existingCountry == null)
            {
                Country newCountry = await _countryRepository.add(new Country() 
                { Name = city.CountryName, Guid = Guid.NewGuid() });

                cityToAdd.CountryGuid = newCountry.Guid;
            }
            else
            {
                cityToAdd.CountryGuid = existingCountry.Guid;
            }

            await _cityRepository.add(cityToAdd);

            cityToAdd.CityImageGuid = await _cityImageAdderService.UploadCityImage(city.File, cityToAdd.Guid);

            ApplicationUser? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user != null)
            {
                if (user.Cities == null)
                {
                    user.Cities = new List<City> { cityToAdd };
                }
                else
                {
                    user.Cities.Add(cityToAdd);
                }

                if (user.Countries == null)
                {
                    user.Countries = new List<Country> { cityToAdd.Country };
                }
                else
                {
                    user.Countries.Add(cityToAdd.Country);
                }

                await _userManager.UpdateAsync(user);
            }

            return cityToAdd.ToCityResponse();
        }
    }
}
