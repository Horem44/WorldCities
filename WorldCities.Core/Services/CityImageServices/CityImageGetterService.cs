using WorldCities.Core.Domain.Entities;
using WorldCities.Core.Domain.RepositoryContracts.CityImageRepositoryContract;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;

namespace WorldCities.Core.Services.CityImageServices
{
    public class CityImageGetterService : ICityImageGetterService
    {
        private readonly ICityImageRepository _cityImageRepository;

        public CityImageGetterService(ICityImageRepository cityImageRepository) 
        {
            _cityImageRepository = cityImageRepository;
        }

        public async Task<CityImage?> getFileByGuid(Guid guid)
        {
            CityImage? image = await _cityImageRepository.getByGuid(guid);

            if (image == null)
            {
                return null;
            }

            return image;
        }
    }
}
