using MediatR;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommand(Guid CityId, Guid UserId) : IRequest<Unit>;
}
