using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Cities.AddCity
{
    public class AddCityCommandMapping : Profile
    {
        public AddCityCommandMapping()
        {
            CreateMap<AddCityCommand, City>()
                .ForMember(z => z.Lat, z => z.MapFrom(x => x.Lat))
                .ForMember(z => z.Lon, z => z.MapFrom(x => x.Lon))
                .ForMember(z => z.Name, z => z.MapFrom(x => x.Name));
        }
    }
}
