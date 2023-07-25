using MediatR;
using WorldCities.Core.Commands.Likes.Models;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommand(Guid CityId, Guid UserId) : IRequest<LikeDto>;
}
