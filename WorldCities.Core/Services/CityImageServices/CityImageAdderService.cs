using Microsoft.AspNetCore.Http;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityImageRepositoryContract;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;

namespace WorldCities.Core.Services.CityImageServices
{
    public class CityImageAdderService : ICityImageAdderService
    {
        private readonly ICityImageRepository _cityImageRepository;

        public CityImageAdderService(ICityImageRepository cityImageRepository)
        {
            _cityImageRepository = cityImageRepository;
        }

        public async Task<Guid> UploadCityImage(IFormFile image)
        {


            await _cityImageRepository.add(image);

            return image.Guid;
        }
    }
}
