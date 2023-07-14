using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.DTO.Cities;
using WorldCities.Core.DTO.Countries;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.CountryServiceContracts;

namespace WorldCities.Core.Services.CountryServices
{
    public class CountryGetterService : ICountryGetterService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CountryGetterService(ICountryRepository countryRepository, UserManager<ApplicationUser> userManager)
        {
            _countryRepository = countryRepository;
            _userManager = userManager;
        }

        public async Task<List<CityResponse>> GetCountryCities(Guid countryId)
        {
            List<City> countryCities = await _countryRepository.GetCountryCities(countryId);
            return countryCities.Select(c => c.ToCityResponse()).ToList();
        }

        public async Task<List<CountryResponse>> GetUserCountries(Guid userGuid)
        {
            ApplicationUser? user = await _userManager.Users
                .Include(u => u.Countries)
                .ThenInclude(c => c.Cities)
                .FirstOrDefaultAsync(u => u.Id == userGuid);

            if (user != null && user.Countries != null)
            {
                List<CountryResponse> userCountries = user.Countries.Select(c => c.ToCountryResponse()).ToList();
                return userCountries;
            }

            return new List<CountryResponse>();

        }
    }
}
