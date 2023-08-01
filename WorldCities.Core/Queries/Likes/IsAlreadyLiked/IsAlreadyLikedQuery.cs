using MediatR;

namespace WorldCities.Core.Queries.Likes.IsAlreadyLiked
{
    public record IsAlreadyLikedQuery(Guid CityId) : IRequest<bool>;
}
