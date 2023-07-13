using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;
using WorldCities.Core.DTO.Cities.Responses;

namespace WorldCities.Core.ServiceContracts.CityServiceContracts
{
    public interface ICitiesGetterService
    {
        Task<List<CityResponse>?> getAllCities();
        Task<CityResponse?> getCityByGuid(Guid? guid);
        Task<List<CityResponse>> GetUserCities(string userId);
    }
}
