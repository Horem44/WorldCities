using AutoMapper;
using WorldCities.Core.Events.Cities.AddCityImageForCreatedCity;
using WorldCities.Core.Events.Cities.AddCountryForCreatedCity;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Events.Cities.BaseCities
{
    public class BaseCitiesMapping : Profile
    {
        public BaseCitiesMapping()
        {
            CreateMap<AddCountryForCreatedCityEvent, Country>()
                .ForMember(z => z.Name, z => z.MapFrom(x => x.CountryName));

            CreateMap<AddCityImageForCreatedCityEvent, CityImage>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId))
                .ForMember(z => z.FileName, z => z.MapFrom(x => x.Image.FileName))
                .ForMember(z => z.ContentType, z => z.MapFrom(x => x.Image.ContentType));
        }
    }
}
