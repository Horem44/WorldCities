using AutoMapper;
using WorldCities.Core.Commands.Likes.Models;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Core.Commands.Likes.BaseLikes
{
    public class BaseLikesMapping : Profile
    {
        public BaseLikesMapping()
        {
            CreateMap<Like, LikeDto>()
                .ForMember(z => z.UserId, z => z.MapFrom(x => x.UserGuid))
                .ForMember(z => z.LikeId, z => z.MapFrom(x => x.Guid));
        }
    }
}
