using Microsoft.AspNetCore.Http;

namespace WorldCities.Core.ServiceContracts.CityImageServiceContracts
{
    public interface ICityImageAdderService
    {
        Task<Guid?> UploadCityImage(IFormFile image);
    }
}
