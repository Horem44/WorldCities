using AutoMapper;
using WorldCities.Core.IntegrationEvents.Likes.RemoveCityLike;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public class RemoveLikeCommandMapping : Profile
    {
        public RemoveLikeCommandMapping()
        {
            CreateMap<RemoveLikeCommand, RemoveCityLikeEvent>()
                .ForMember(z => z.CityId, z => z.MapFrom(x => x.CityId));
        }
    }
}
