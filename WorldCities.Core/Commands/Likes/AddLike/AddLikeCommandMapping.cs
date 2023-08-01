using AutoMapper;
using WorldCities.Core.IntegrationEvents.Likes.AddLike;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public class AddLikeCommandMapping : Profile
    {
        public AddLikeCommandMapping()
        {
            CreateMap<AddLikeCommand, AddCityLikeEvent>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId));
        }
    }
}
