using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Countries.GetUserCountries
{
    public class GetUserCountriesMapping : Profile
    {
        public GetUserCountriesMapping()
        {
            CreateMap<Country, CountryDto>()
                .ForMember(z => z.Guid, z => z.MapFrom(x => x.Id))
                .ForMember(z => z.CitiesCount, z => z.MapFrom(x => x.CitiesCount))
                .ForMember(z => z.Name, z => z.MapFrom(x => x.Name));
        }
    }
}
