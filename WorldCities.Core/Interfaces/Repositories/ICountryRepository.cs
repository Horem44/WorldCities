using WorldCities.Domain.Entities.Cities;
using WorldCities.Domain.Entities.Countries;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country?> GetByName(string name, CancellationToken cancellationToken);

        Task<List<City>> GetCountryCities(Guid countryGuid, CancellationToken cancellationToken);
    }
}
