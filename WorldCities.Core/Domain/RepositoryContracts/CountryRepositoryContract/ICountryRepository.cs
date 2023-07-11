using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCities.Core.Domain.Entities;

namespace WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country?> GetByName(string name);
    }
}
