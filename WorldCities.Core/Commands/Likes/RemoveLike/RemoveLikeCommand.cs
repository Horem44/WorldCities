using MediatR;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public record RemoveLikeCommand(Guid CityId) : IRequest<Unit>;
}
