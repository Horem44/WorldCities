using AutoMapper;
using MediatR;
using WorldCities.Core.Commands.Likes.Models;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Domain.Entities.Likes;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommandHandler(ILikeRepository LikeRepository, IMapper Mapper)
        : IRequestHandler<AddLikeCommand, LikeDto>
    {
        public async Task<LikeDto> Handle(
            AddLikeCommand request,
            CancellationToken cancellationToken
        )
        {
            Like like = new Like() { CityGuid = request.CityId, UserGuid = request.UserId };
            await LikeRepository.Add(like, cancellationToken);

            return Mapper.Map<LikeDto>(like);
        }
    }
}
