using AutoMapper;
using WorldCities.Core.IntegrationEvents.Likes.AddLike;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public class AddLikeCommandMapping : Profile
    {
        public AddLikeCommandMapping()
        {
            CreateMap<AddLikeCommand, Like>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId));

            CreateMap<AddLikeCommand, AddCityLikeEvent>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId));
        }
    }
}
