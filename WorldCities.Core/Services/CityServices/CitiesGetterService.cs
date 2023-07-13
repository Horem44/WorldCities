using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.DTO.Cities.Responses;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.CityServiceContracts;

namespace WorldCities.Core.Services.CityServices
{
    public class CitiesGetterService : ICitiesGetterService
    {
        private readonly ICityRepository _cityRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CitiesGetterService(ICityRepository cityRepository, UserManager<ApplicationUser> userManager)
        {
            _cityRepository = cityRepository;
            _userManager = userManager;
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

        public async Task<List<CityResponse>> GetUserCities(string userId)
        {
            ApplicationUser? user = _userManager.Users
                .Include(u => u.Cities).FirstOrDefault(u => u.Id == Guid.Parse(userId));

            if (user != null && user.Cities != null)
            {
                List<CityResponse> userCities = user.Cities.Select(c => c.ToCityResponse()).ToList();
                return userCities;
            }

            return new List<CityResponse>();
        }
    }
}
