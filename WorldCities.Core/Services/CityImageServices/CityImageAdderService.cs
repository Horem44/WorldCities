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

        public async Task<Guid?> UploadCityImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return null;
            }

            CityImage imageEntity = new CityImage()
            {
                FileName = image.FileName,
                ContentType = image.ContentType
            };

            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                imageEntity.FileData = memoryStream.ToArray();
            }

            await _cityImageRepository.add(imageEntity);

            return imageEntity.Guid;
        }
    }
}
