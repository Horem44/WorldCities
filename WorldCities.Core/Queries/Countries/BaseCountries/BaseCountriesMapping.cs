using AutoMapper;
using WorldCities.Core.Queries.Countries.Models;
using WorldCities.Domain.Entities.Countries;

namespace WorldCities.Core.Queries.Countries.BaseCountries
{
    public class BaseCountriesMapping : Profile
    {
        public BaseCountriesMapping()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(z => z.Guid, z => z.MapFrom(x => x.Guid))
                .ForMember(z => z.CitiesCount, z => z.MapFrom(x => x.CitiesCount))
                .ForMember(z => z.Name, z => z.MapFrom(x => x.Name));
        }
    }
}
