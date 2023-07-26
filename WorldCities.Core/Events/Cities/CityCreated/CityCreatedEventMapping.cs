using AutoMapper;
using MediatR;
using System.Net.Mime;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Events.Cities.CityCreated
{
    public class CityCreatedEventMapping : Profile
    {
        public CityCreatedEventMapping()
        {
            CreateMap<CityCreatedEvent, Country>()
                .ForMember(z => z.Name, z => z.MapFrom(x => x.CountryName));

            CreateMap<CityCreatedEvent, CityImage>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId))
                .ForMember(z => z.FileName, z => z.MapFrom(x => x.Image.FileName))
                .ForMember(z => z.ContentType, z => z.MapFrom(x => x.Image.ContentType));
        }
    }
}
