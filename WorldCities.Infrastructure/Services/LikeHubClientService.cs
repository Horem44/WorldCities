using Microsoft.AspNetCore.SignalR;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Domain.Constants;
using WorldCities.Infrastructure.Hubs;

namespace WorldCities.Infrastructure.Services
{
    public record LikeHubClientService(IHubContext<LikeHub> LikeHubContext) : ILikeHubClientService
    {
        public Task IncreaseCityLikes(Guid id, CancellationToken cancellationToken)
        {
            return LikeHubContext.Clients.All.SendAsync(
                SignalRLikeMessageConstants.INCREASE_CITY_LIKES,
                id,
                cancellationToken
            );
        }

        public Task DecreaseCityLikes(Guid id, CancellationToken cancellationToken)
        {
            return LikeHubContext.Clients.All.SendAsync(
                SignalRLikeMessageConstants.DECREASE_CITY_LIKES,
                id,
                cancellationToken
            );
        }
    }
}
