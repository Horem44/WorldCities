using WorldCities.Domain.Entities;

namespace WorldCities.Core.Interfaces.Repositories
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        IQueryable<Country> GetByName(string name);
    }
}
