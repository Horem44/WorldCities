using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Queries.CityImages.GetCityImageById
{
    public class GetCityImageByIdMapping : Profile
    {
        public GetCityImageByIdMapping()
        {
            CreateMap<CityImage, CityImageDto>()
                .ForMember(z => z.MemoryStream, z => z.MapFrom(x => new MemoryStream(x.FileData)))
                .ForMember(z => z.ContentType, z => z.MapFrom(x => x.ContentType));
        }
    }
}
