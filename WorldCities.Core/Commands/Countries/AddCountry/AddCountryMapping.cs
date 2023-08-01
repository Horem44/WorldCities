using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Countries.AddCountry
{
    public class AddCountryMapping : Profile
    {
        public AddCountryMapping()
        {
            CreateMap<AddCountryCommand, Country>()
                .ForMember(z => z.Name, z => z.MapFrom(x => x.CountryName));
        }
    }
}
