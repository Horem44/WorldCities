using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.ServiceContracts.CityImageServiceContracts
{
    public interface ICityImageGetterService
    {
        Task<CityImage?> getFileByGuid(Guid guid);
    }
}
