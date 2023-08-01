using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.DomainEvents.Cities.AddCityImageForCreatedCity
{
    public class AddCityImageForCreatedCityMapping : Profile
    {
        public AddCityImageForCreatedCityMapping()
        {
            CreateMap<AddCityImageForCreatedCityEvent, CityImage>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId))
                .ForMember(z => z.FileName, z => z.MapFrom(x => x.Image.FileName))
                .ForMember(z => z.ContentType, z => z.MapFrom(x => x.Image.ContentType));
        }
    }
}
