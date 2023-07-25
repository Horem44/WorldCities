using MediatR;

namespace WorldCities.Core.Commands.Likes.RemoveLike
{
    public record RemoveLikeCommand(Guid userId, Guid cityId) : IRequest<Guid>;
}
