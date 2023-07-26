using AutoMapper;
using WorldCities.Core.Queries.Cities.Models;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.Cities.BaseCities
{
    public class BaseCitiesMapping : Profile
    {
        public BaseCitiesMapping()
        {
            CreateMap<City, CityDto>()
                .ForMember(z => z.Guid, z => z.MapFrom(x => x.Id))
                .ForMember(z => z.LikesCount, z => z.MapFrom(x => x.LikesCount))
                .ForMember(z => z.Name, z => z.MapFrom(x => x.Name))
                .ForMember(z => z.Lat, z => z.MapFrom(x => x.Lat))
                .ForMember(z => z.Lon, z => z.MapFrom(x => x.Lon))
                .ForMember(z => z.CountryName, z => z.MapFrom(x => x.Country.Name))
                .ForMember(z => z.CityImageId, z => z.MapFrom(x => x.CityImageId));
        }
    }
}
