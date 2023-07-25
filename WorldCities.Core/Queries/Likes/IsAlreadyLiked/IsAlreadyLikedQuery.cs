using MediatR;

namespace WorldCities.Core.Queries.Likes.IsAlreadyLiked
{
    public record IsAlreadyLikedQuery(Guid userId, Guid cityId) : IRequest<bool>;
}
