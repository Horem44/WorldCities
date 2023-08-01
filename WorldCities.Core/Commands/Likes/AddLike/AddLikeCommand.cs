using MediatR;

namespace WorldCities.Core.Commands.Likes.AddLike
{
    public record AddLikeCommand(Guid CityId) : IRequest<Unit>;
}
