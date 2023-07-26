using AutoMapper;
using WorldCities.Domain.Entities;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public class AddLikeCommandMapping : Profile
    {
        public AddLikeCommandMapping()
        {
            CreateMap<AddLikeCommand, Like>()
                .ForMember(z => z.UserGuid, z => z.MapFrom(x => x.UserId))
                .ForMember(z => z.CityGuid, z => z.MapFrom(x => x.CityId));
        }
    }
}
